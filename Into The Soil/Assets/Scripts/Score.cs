using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreText;
    public float scoreValue;
    public float pointIncreasedPerSecond;

    private CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0f;
        pointIncreasedPerSecond = 5f;

        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraController.shouldReverse == false)
        {
            scoreText.text = "Score: " + (int)scoreValue;
            scoreValue += pointIncreasedPerSecond * Time.deltaTime;
        }
        
    }
}
