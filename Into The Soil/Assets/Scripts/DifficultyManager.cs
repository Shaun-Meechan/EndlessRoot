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

    private void Start()
    {
        Initialise();
        difficultyTimer.StartTimer(45,IncreaseDifficulty, true);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += (acceleration * Time.deltaTime);
        playerMovement.SetSpeed(currentSpeed);
    }

    void IncreaseDifficulty()
    {
        if(currentDifficulty >= 5)
        {
            difficultyTimer.Dispose();
            return;
        }
        currentDifficulty ++;
        acceleration *= MathF.Pow(currentDifficulty, 0.9f);
        denseOfObstacle += currentDifficulty;
        cameraSpeed = currentSpeed * 0.8f;
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
