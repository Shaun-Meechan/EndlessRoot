using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    const int countOfScorePowerUps = 3;
    public GameObject scorePowerUpPrefab;
    GameObject[] scorePowerUps = new GameObject[countOfScorePowerUps];
    GameObject firstAvaliableScorePowerUp;

    const int countOfWaterPowerUps = 3;
    public GameObject WaterPowerUpPrefab;
    GameObject[] waterPowerUps = new GameObject[countOfWaterPowerUps];
    GameObject firstAvaliableWaterPowerUp;

    const int countOfNutritionPowerUps = 3;
    public GameObject nutritionPowerUpPrefab;
    GameObject[] nutritionPowerUps = new GameObject[countOfNutritionPowerUps];
    GameObject firstAvaliableNutritionPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < countOfScorePowerUps; i++)
        {
            GameObject go = Instantiate(scorePowerUpPrefab, transform.position, Quaternion.identity);
            scorePowerUps[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < countOfScorePowerUps - 1; i++)
        {
            scorePowerUps[i].GetComponent<ScorePickup>().setNextnextPowerUp(scorePowerUps[i + 1]);
        }

        firstAvaliableScorePowerUp = scorePowerUps[0];
        scorePowerUps[countOfScorePowerUps - 1].GetComponent<ScorePickup>().setNextnextPowerUp(null);


        //for (int i = 0; i < countOfWaterPowerUps; i++)
        //{
        //    GameObject go = Instantiate(WaterPowerUpPrefab, transform.position, Quaternion.identity);
        //    waterPowerUps[i] = go;
        //    go.SetActive(false);
        //}

        //for (int i = 0; i < countOfWaterPowerUps - 1; i++)
        //{
            //waterPowerUps[i].GetComponent<WaterPickup>().setNextnextPowerUp(waterPowerUps[i + 1]);
        //}

        //firstAvaliableWaterPowerUp = waterPowerUps[0];
        //waterPowerUps[countOfWaterPowerUps - 1].GetComponent<WaterPickup>().setNextnextPowerUp(null);


        for (int i = 0; i < countOfNutritionPowerUps; i++)
        {
            GameObject go = Instantiate(nutritionPowerUpPrefab, transform.position, Quaternion.identity);
            nutritionPowerUps[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < countOfNutritionPowerUps - 1; i++)
        {
            nutritionPowerUps[i].GetComponent<NutritionPowerUp>().setNextnextPowerUp(nutritionPowerUps[i + 1]);
        }

        firstAvaliableScorePowerUp = nutritionPowerUps[0];
        nutritionPowerUps[countOfNutritionPowerUps - 1].GetComponent<NutritionPowerUp>().setNextnextPowerUp(null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
