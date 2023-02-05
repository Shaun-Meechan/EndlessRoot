using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private RootMovement playerMovement;

    private CustomTimer difficultyTimer;


    [SerializeField]
    int currentDifficulty = 1;

    [SerializeField]
    float currentSpeed = 3;

    [SerializeField]
    float acceleration = 0.1f;

    [SerializeField]
    float cameraSpeed = 1.5f;

    [SerializeField]
    float denseOfObstacle = 1;

    bool shouldClampToCameraSpped = false;
    float speedBeforeClamp;

    CameraController cameraController;

    private void Start()
    {
        Initialise();
        difficultyTimer.StartTimer(45,IncreaseDifficulty, true);
        cameraController = Camera.main.GetComponent<CameraController>();

    }

    // Update is called once per frame
    void Update()
    {
        //currentSpeed += (acceleration * Time.deltaTime);
        //currentSpeed = Mathf.Clamp(currentSpeed + (acceleration * Time.deltaTime), 0, 30);
        currentSpeed = Mathf.Clamp(cameraSpeed + (acceleration * Time.deltaTime), 0, 30);


        if (shouldClampToCameraSpped)
        {
            currentSpeed = cameraController.speed;
        }
        else
        {
            currentSpeed *= 1.2f;
        }

        playerMovement.SetSpeed(currentSpeed);
    }

    public void clampToCameraSpeed()
    {
        speedBeforeClamp = currentSpeed;
        shouldClampToCameraSpped = true;
    }

    public void unclampToCameraSpeed()
    {
        shouldClampToCameraSpped = false;
        currentSpeed = speedBeforeClamp;
    }

    void IncreaseDifficulty()
    {
        if(currentDifficulty >= 10)
        {
            difficultyTimer.Dispose();
            return;
        }
        currentDifficulty ++;
        acceleration *= MathF.Pow(currentDifficulty, 0.9f);
        denseOfObstacle += currentDifficulty;

        if(shouldClampToCameraSpped)
        {
            cameraSpeed = speedBeforeClamp * 0.8f;
        }
        else
        {
            cameraSpeed = currentSpeed * 0.8f;
        }
    }

    public int GetDifficulty()
    {
        return currentDifficulty; 
    }

    private void Initialise()
    {
        playerMovement = playerObject.GetComponent<RootMovement>();
        difficultyTimer = gameObject.AddComponent<CustomTimer>();
    }
}
