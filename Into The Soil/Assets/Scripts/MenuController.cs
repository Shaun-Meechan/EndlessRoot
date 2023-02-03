using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class MenuController : MonoBehaviour
{

    [SerializeField] public GameObject splashScreen;
    [SerializeField] public GameObject menuScreen;

    public bool isPaused;

    public bool isSplashScreen;



    private void Start()
    {
        isSplashScreen = true;

    }

    private void Update()
    {
        SplashScreenTransition();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void SplashScreenTransition()
    {
        if (isSplashScreen == true && Input.anyKey)
        {
            menuScreen.SetActive(true);
            splashScreen.SetActive(false);
        }
    }

    public void Play()
    {
        Debug.Log("Play!");
    }

    public void Pause()
    {
        
    }

    public void Resume()
    {
        
    }

    public void GoToMainMenu()
    {
        
    }

    public void playAgain()
    {
        
    }


    public void Quit()
    {
        Application.Quit();
    }

}
