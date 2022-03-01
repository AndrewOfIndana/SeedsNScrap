using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static bool isGamePaused = false;
    private bool isMarketOpen = false;
    private Camera playerCamera;
    public GameObject pauseMenuUI;
    public GameObject marketMenuUI;

    void Awake()
    {
        playerCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isGamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (isMarketOpen == true)
            {
                MarketClose();
            }
            else
            {
                MarketOpen();
            }
        }

    }

    //[Pause Menu]

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        playerCamera.SendMessage("CameraResume");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        playerCamera.SendMessage("CameraPause");
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    //[Market Menu]

    public void MarketClose() 
    {
        marketMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isMarketOpen = false;
        playerCamera.SendMessage("CameraResume");
    }

    public void MarketOpen() 
    {
        marketMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isMarketOpen = true;
        playerCamera.SendMessage("CameraPause");
    }

    public void DefaultButton() 
    {
        Debug.Log("This button works but has been disabled for now");
    }

}
