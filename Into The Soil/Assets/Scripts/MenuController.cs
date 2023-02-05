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

    private bool isSplashScreen;
    private bool camIsMoving;

    public int sceneIndexToLoad = 0;

    public Camera cam;

    private void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;

        cam = FindObjectOfType<Camera>();

        if (splashScreen != null)
        {
            isSplashScreen = true;
        }
        

    }


    private void Update()
    {

        SplashScreenTransition();

        if (camIsMoving == true)
        {
            cam.transform.SetPositionAndRotation(new Vector3(0, cam.transform.position.y - (5f * Time.deltaTime), -10), Quaternion.identity);
        }

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
           
            

            camIsMoving = true;
            splashScreen.SetActive(false);
            isSplashScreen = false;
        }
        
        if (cam.transform.position.y <= -9.14f)
        {
            camIsMoving = false;

            mainMenuScreen.SetActive(true);
            
            
        }
    }

    public void Play()
    {
        isPaused = false;
        Time.timeScale = 1f;
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

    public void GameOver()
    {
        isPaused = true;
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);

        
    }

    public void playAgain()
    {
        isPaused = false;
        Time.timeScale = 1f;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(sceneIndexToLoad);
    }


    public void Quit()
    {
        Application.Quit();
    }

}
