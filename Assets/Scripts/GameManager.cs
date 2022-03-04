using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//Revised
public class GameManager : MonoBehaviour
{
    //Waves states
    public enum SpawnState {SPAWNING, WAITING, COUNTING}; //State of whether bugs are spawning, waiting for timer, or out
    public float timeBetweenWaves = 10f; //Time between waves
    public float timeStart = 200f; //Time before waves
    //References
    public GameObject nest; //The nest where bugs spawn
    public GameObject bugPrefab; //The bug prefab

    [Header("Waves")]
    public Waves[] waves; //Array of wave objects, should have bug count, bug types, and spawn rate for each wave object
    private int waveNum = 0; //The wave number
    private float WaveCountDownTime; //The count down timer, will go down with time.delta time
    private float bugCheckTime = 1f; //The time it takes to check for bugs 
    private SpawnState state = SpawnState.COUNTING; //The acutal state that will be used for checking waves

    //Header("Life")
    private float lifeMax = 100; //Max amount of life, could change possilbly with upgrades
    float life = 0; //The acutal life stat of the player goes up instead of down

    //Header("Money")
    public float money = 200; //The amount of money the player holds

    //Header("Crops")
    private float cropNum = 0; //The number of crops currently in game
    private float cropNumMax = 30; //The max amount of crops, could change

    [Header("UI")]
    public TMP_Text waveUI; //Text for the wave number
    public TMP_Text moneyUI; //Text for the amount of money
    public TMP_Text cropNumUI; //Text for the number of current crops over the max
    public Image lifeUI; //Image of the life meter

    void Awake() //Starts fisrt frame
    {
        WaveCountDownTime = timeStart; //Sets wave count down with the starting time
        UIupdate(); //Changes UI
    }
    
    void Update() //Every frame, within time scale
    {
        if(state == SpawnState.WAITING)
        {
            if (!BugsAreAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (WaveCountDownTime <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave (waves[waveNum]));
            }
        }
        else
        {
            WaveCountDownTime -= Time.deltaTime;
        }
    }

    //Wave Manager

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        WaveCountDownTime = timeBetweenWaves;

        waveNum++;
        UIupdate();

        if (waveNum + 1 > waves.Length)
        {
            waveNum = 0;
            Debug.Log("All waves complete, Looping");
        }
    }

    bool BugsAreAlive() // checks if bugs are alive
    {
        bugCheckTime -= Time.deltaTime;
        if(bugCheckTime <= 0)
        {
            bugCheckTime = 1f;
            if (GameObject.FindGameObjectWithTag("_Bug") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Waves _wave) //spawns wave
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.bugCount; i++)
        {
            SpawnBug(_wave.bugID);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnBug(int[] IDs) //spawns bugs
    {
        GameObject bugPrefabGameObj = Instantiate(bugPrefab, nest.transform.position, Quaternion.identity);
        bugPrefabGameObj.SendMessage("SetModel", IDs); //Sets model and script of bug
    }
    
    //Health Manager

    public void LoseHealth()
    {
        life += 10;
        UIupdate();
    }

    //Money Manager

        public void LoseMoney(float funds)
        {
            money -= funds;
            cropNum += 1;
            UIupdate();
        }
        public void AddMoney(float funds)
        {
            money += funds;
            cropNum -= 1;
            UIupdate();
        }


    //Crop Manager

        //Insert
    
    //UI Manager

    public void UIupdate()
    {
        waveUI.text = (waveNum+1).ToString();
        moneyUI.text = "$ " + money.ToString();
        cropNumUI.text = "Crops: " + cropNum + " / " + cropNumMax;
        lifeUI.fillAmount = 1 - (life / lifeMax);
    }
}
