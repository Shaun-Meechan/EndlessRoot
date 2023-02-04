using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    const int maxEnemies = 3;
    public GameObject enemyObject;
    GameObject[] enemyObjects = new GameObject[maxEnemies];
    GameObject firstAvaliableEnemy;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject go = Instantiate(enemyObject, transform.position, Quaternion.identity);
            enemyObjects[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < maxEnemies - 1; i++)
        {
            enemyObjects[i].GetComponent<EnemyController>().setNextEnemy(enemyObjects[i + 1]);
        }

        firstAvaliableEnemy = enemyObjects[0];
        enemyObjects[maxEnemies - 1].GetComponent<EnemyController>().setNextEnemy(null);
    }

    public void spawnEnemy(float YValue)
    {
        firstAvaliableEnemy.transform.SetPositionAndRotation(new Vector3(Random.Range(-8, 8), 0 + YValue, 0), Quaternion.identity);
        firstAvaliableEnemy.SetActive(true);
        firstAvaliableEnemy = firstAvaliableEnemy.GetComponent<EnemyController>().getNextEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            if(enemyObjects[i].GetComponent<EnemyController>().getIsBehind())
            {
                enemyObjects[i].GetComponent<EnemyController>().setNextEnemy(firstAvaliableEnemy);
                firstAvaliableEnemy = enemyObjects[i];
                firstAvaliableEnemy.SetActive(false);
                firstAvaliableEnemy.GetComponent<EnemyController>().setIsBehind(false);
            }
        }   
    }
}
