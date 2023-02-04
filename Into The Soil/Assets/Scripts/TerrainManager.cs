using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{

    const int maxTiles = 4;
    public GameObject tileObject;
    GameObject[] tileObjects = new GameObject[maxTiles];

    GameObject firstAvaliableTile;

    public EnemyManager enemyManager;
    public RockManager rockManager;

    int tileCounter = -10;

    const int maxY = -100000;

        // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTiles; i++)
        {
            GameObject go = Instantiate(tileObject, transform.position, Quaternion.identity);
            tileObjects[i] = go;
            go.SetActive(false);
            go.GetComponent<Terrain>().setTerrainManager(this);
        }

        for (int i = 0; i < maxTiles - 1; i++)
        {
            tileObjects[i].GetComponent<Terrain>().setNextTile(tileObjects[i + 1]);
        }

        firstAvaliableTile = tileObjects[0];
        tileObjects[maxTiles - 1].GetComponent<Terrain>().setNextTile(null);

        spawnTile();
        spawnTile();
    }

    public void spawnTile()
    {
        //TODO: How do we stop floating point loss of precision but keep the trail
        firstAvaliableTile.transform.SetPositionAndRotation(new Vector3(0, 0 + tileCounter, 0), Quaternion.identity);
        int randomChance = Random.Range(0, 11);

        if(randomChance >= 0)
        {
            //Spawn power up
            //Instantiate(powerUp, new Vector3(Random.Range(-8, 8), 0 + (tileCounter + 10), 0), Quaternion.identity);
            enemyManager.spawnEnemy(tileCounter, firstAvaliableTile);
        }

        //Spawn some rock
        int rocksToSpawn = Random.Range(0, 5);

        for (int i = 0; i < rocksToSpawn; i++)
        {
            rockManager.spawnRock(tileCounter, firstAvaliableTile);
        }

        firstAvaliableTile.SetActive(true);
        firstAvaliableTile = firstAvaliableTile.GetComponent<Terrain>().getNextTile();
        tileCounter -= 10;

        if(tileCounter <= maxY)
        {
            tileCounter = -10;
        }


    }


    //Called when the game is over to show all tiles
    public void showAlltiles()
    {
        Vector3 spawnPosition = new Vector3(0, -10, 0);
        for (int i = -10; i > tileCounter; i-= 10)
        {
            spawnPosition.y = i;
            Instantiate(tileObject, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < maxTiles; i++)
        {
            if(tileObjects[i].GetComponent<Terrain>().getIsBehind())
            {
                tileObjects[i].GetComponent<Terrain>().setNextTile(firstAvaliableTile);
                firstAvaliableTile = tileObjects[i];
                firstAvaliableTile.SetActive(false);
                firstAvaliableTile.GetComponent<Terrain>().setisBehind(false);
            }
        }
    }
}
