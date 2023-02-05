using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    const int maxRocks = 8;
    public GameObject rockObject;
    GameObject[] rockObjects = new GameObject[maxRocks];

    GameObject firstAvaliableRock;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxRocks; i++)
        {
            GameObject go = Instantiate(rockObject, transform.position, Quaternion.identity);
            rockObjects[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < maxRocks - 1; i++)
        {
            rockObjects[i].GetComponent<RedirectionRock>().setNextRock(rockObjects[i + 1]);
        }

        firstAvaliableRock = rockObjects[0];
        rockObjects[maxRocks - 1].GetComponent<RedirectionRock>().setNextRock(null);
    }

    public void spawnRock(float YValue, GameObject tile)
    {
        if(firstAvaliableRock == null)
        {
            //We ran out of rocks
            return;
        }
        firstAvaliableRock.transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 9), 0 + YValue + (Random.Range(-4, 5)), 0), rockObject.transform.rotation);
        firstAvaliableRock.transform.parent = tile.transform;
        firstAvaliableRock.SetActive(true);
        firstAvaliableRock = firstAvaliableRock.GetComponent<RedirectionRock>().getNextRock();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxRocks; i++)
        {
            if(rockObjects[i].GetComponent<RedirectionRock>().getIsBehind())
            {
                rockObjects[i].GetComponent<RedirectionRock>().setNextRock(firstAvaliableRock);
                firstAvaliableRock = rockObjects[i];
                firstAvaliableRock.SetActive(false);
                firstAvaliableRock.GetComponent<RedirectionRock>().setIsBehind(false);
            }
        }
    }
}
