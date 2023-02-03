using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{

    const int maxTiles = 4;
    public GameObject tileObject;
    GameObject[] tileObjects = new GameObject[maxTiles];

    GameObject firstAvaliableTile;

    int tileCounter = -10;

        // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTiles; i++)
        {
            GameObject go = Instantiate(tileObject, transform.position, Quaternion.identity);
            tileObjects[i] = go;
            go.SetActive(false);
        }

        for (int i = 0; i < maxTiles - 1; i++)
        {
            tileObjects[i].GetComponent<Terrain>().setNextTile(tileObjects[i + 1]);
        }

        firstAvaliableTile = tileObjects[0];
        tileObjects[maxTiles - 1].GetComponent<Terrain>().setNextTile(null);

        spawnTile();
    }

    public void spawnTile()
    {
        firstAvaliableTile.transform.SetPositionAndRotation(new Vector3(0, 0 + tileCounter, 0), Quaternion.identity);
        firstAvaliableTile.SetActive(true);
        firstAvaliableTile = firstAvaliableTile.GetComponent<Terrain>().getNextTile();
        tileCounter -= 10;

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
            }
        }
    }
}
