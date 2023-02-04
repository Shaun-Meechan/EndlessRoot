using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{

    [SerializeField] public GameObject splashScreen;
    [SerializeField] public GameObject mainMenuScreen;

    [SerializeField] public GameObject pauseMenuScreen;
    [SerializeField] public GameObject gameOverScreen;

    public bool isPaused;

    public bool isSplashScreen;

    public int sceneIndexToLoad = 0;



    private void Start()
    {
        if (splashScreen != null)
        {
            isSplashScreen = true;
        }
        

    }

    private void Update()
    {
        SplashScreenTransition();

        if (pauseMenuScreen != null && Input.GetKeyDown(KeyCode.Escape))
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
            mainMenuScreen.SetActive(true);
            splashScreen.SetActive(false);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuScreen.SetActive(true);

        Debug.Log("isPaused = " + isPaused);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuScreen.SetActive(false);

        Debug.Log("isPaused = " + isPaused);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void playAgain()
    {
        
    }


    public void Quit()
    {
        Application.Quit();
    }

}
