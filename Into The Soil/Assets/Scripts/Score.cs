using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    public float scoreValue;
    public float pointIncreasedPerMeter;

    private CameraController cameraController;

    private RootMovement rootMovement;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0f;
        pointIncreasedPerMeter = 5f;

        cameraController = FindObjectOfType<CameraController>();
        rootMovement = FindObjectOfType<RootMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraController.shouldReverse == false)
        {
            scoreText.text = "Score: " + (int)scoreValue;
            if (rootMovement.currentDir == Dir.Down)
            {
                scoreValue += pointIncreasedPerMeter * Time.deltaTime;
            }
            
        }
        
    }
}
