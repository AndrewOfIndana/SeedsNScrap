using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play() 
    {
        //Level Select
        SceneManager.LoadScene("GameScene");
    }

    public void Garden()
    {
        Debug.Log("This access the garden");
    }

    public void Options()
    {
        Debug.Log("This access the options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
