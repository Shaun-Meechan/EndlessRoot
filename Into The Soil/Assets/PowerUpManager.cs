using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    const int countOfAccessoryPickUp = 3;
    public GameObject[] AccessoryPickUpPrefabs;
    GameObject[] AccessoryPickUps = new GameObject[countOfAccessoryPickUp];
    GameObject firstAvaliableAccessoryPickUp;

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
        for (int i = 0; i < countOfAccessoryPickUp; i++)
        {
            GameObject go = Instantiate(AccessoryPickUpPrefabs[i], transform.position, Quaternion.identity);
            AccessoryPickUps[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < countOfAccessoryPickUp - 1; i++)
        {
            AccessoryPickUps[i].GetComponent<Accessory>().setNextnextPowerUp(AccessoryPickUps[i + 1]);
        }

        firstAvaliableAccessoryPickUp = AccessoryPickUps[0];
        AccessoryPickUps[countOfAccessoryPickUp - 1].GetComponent<Accessory>().setNextnextPowerUp(null);


        for (int i = 0; i < countOfWaterPowerUps; i++)
        {
            GameObject go = Instantiate(WaterPowerUpPrefab, transform.position, Quaternion.identity);
            waterPowerUps[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < countOfWaterPowerUps - 1; i++)
        {
            waterPowerUps[i].GetComponent<Water>().setNextnextPowerUp(waterPowerUps[i + 1]);
        }

        firstAvaliableWaterPowerUp = waterPowerUps[0];
        waterPowerUps[countOfWaterPowerUps - 1].GetComponent<Water>().setNextnextPowerUp(null);

        //for (int i = 0; i < countOfNutritionPowerUps; i++)
        //{
        //    GameObject go = Instantiate(nutritionPowerUpPrefab, transform.position, Quaternion.identity);
        //    nutritionPowerUps[i] = go;
        //    go.SetActive(false);
        //}

        //for (int i = 0; i < countOfNutritionPowerUps - 1; i++)
        //{
        //    nutritionPowerUps[i].GetComponent<NutritionPowerUp>().setNextnextPowerUp(nutritionPowerUps[i + 1]);
        //}

        //firstAvaliableNutritionPowerUp = nutritionPowerUps[0];
        //nutritionPowerUps[countOfNutritionPowerUps - 1].GetComponent<NutritionPowerUp>().setNextnextPowerUp(null);
    }

    public void spawnAccessory(float YValue, GameObject tile)
    {
        if (firstAvaliableAccessoryPickUp == null)
        {
            //We ran out of rocks
            return;
        }
        firstAvaliableAccessoryPickUp.transform.parent = tile.transform;
        firstAvaliableAccessoryPickUp.transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 9), 0 + YValue + (Random.Range(-4, 5)), 0), Quaternion.identity);
        firstAvaliableAccessoryPickUp.SetActive(true);
        firstAvaliableAccessoryPickUp = firstAvaliableAccessoryPickUp.GetComponent<Accessory>().getNextAccessory();
    }    
    
    public void spawnWater(float YValue, GameObject tile)
    {
        if (firstAvaliableWaterPowerUp == null)
        {
            //We ran out of rocks
            return;
        }
        firstAvaliableWaterPowerUp.transform.parent = tile.transform;
        firstAvaliableWaterPowerUp.transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 9), 0 + YValue + (Random.Range(-4, 5)), 0), Quaternion.identity);
        firstAvaliableWaterPowerUp.SetActive(true);
        firstAvaliableWaterPowerUp = firstAvaliableWaterPowerUp.GetComponent<Water>().getNexWaterPowerUp();
    }    
    
    public void spawnNutrition(float YValue, GameObject tile)
    {
        if (firstAvaliableNutritionPowerUp == null)
        {
            //We ran out of rocks
            return;
        }
        firstAvaliableNutritionPowerUp.transform.parent = tile.transform;
        firstAvaliableNutritionPowerUp.transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 9), 0 + YValue + (Random.Range(-4, 5)), 0), Quaternion.identity);
        firstAvaliableNutritionPowerUp.SetActive(true);
        firstAvaliableNutritionPowerUp = firstAvaliableAccessoryPickUp.GetComponent<NutritionPowerUp>().getNextPowerUp();
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < countOfAccessoryPickUp; i++)
        {
            if (AccessoryPickUps[i].GetComponent<Accessory>().getIsBehind())
            {
                AccessoryPickUps[i].GetComponent<Accessory>().setNextnextPowerUp(firstAvaliableAccessoryPickUp);
                firstAvaliableAccessoryPickUp = AccessoryPickUps[i];
                firstAvaliableAccessoryPickUp.SetActive(false);
                firstAvaliableAccessoryPickUp.GetComponent<Accessory>().setisBehind(false);
            }
        }        
        
        for (int i = 0; i < countOfWaterPowerUps; i++)
        {
            if (waterPowerUps[i].GetComponent<Water>().getIsBehind())
            {
                waterPowerUps[i].GetComponent<Water>().setNextnextPowerUp(firstAvaliableWaterPowerUp);
                firstAvaliableWaterPowerUp = waterPowerUps[i];
                firstAvaliableWaterPowerUp.SetActive(false);
                firstAvaliableWaterPowerUp.GetComponent<Water>().setisBehind(false);
            }
        }
        
        //for (int i = 0; i < countOfNutritionPowerUps; i++)
        //{
        //    if (nutritionPowerUps[i].GetComponent<NutritionPowerUp>().getIsBehind())
        //    {
        //        nutritionPowerUps[i].GetComponent<NutritionPowerUp>().setNextnextPowerUp(firstAvaliableNutritionPowerUp);
        //        firstAvaliableNutritionPowerUp = nutritionPowerUps[i];
        //        firstAvaliableNutritionPowerUp.SetActive(false);
        //        firstAvaliableNutritionPowerUp.GetComponent<NutritionPowerUp>().setisBehind(false);
        //    }
        //}

    }
}
