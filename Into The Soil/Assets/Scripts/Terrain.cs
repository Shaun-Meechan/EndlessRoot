using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public GameObject getNextTile() { return nextTile; }
    public void setNextTile(GameObject next) { nextTile = next; }
    GameObject nextTile;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setisBehind(bool value) { isBehind = value; }

    TerrainManager terrainManager;
    public void setTerrainManager(TerrainManager input) { terrainManager = input; }

    public void setWalls(GameObject walls) { sideWalls = walls; }
    GameObject sideWalls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            return;
        }
        Debug.Log("Collision!");
        StartCoroutine(behindTimer());
    }

    IEnumerator behindTimer()
    {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 4; i++)
        {
            if(GetComponentInChildren<Rock>())
            {
                GetComponentInChildren<Rock>().setIsBehind(true);
            }
            else
            {
                break;
            }
        }

        if(GetComponentInChildren<EnemyController>())
        {
            GetComponentInChildren<EnemyController>().setIsBehind(true);
        }

        sideWalls.GetComponent<Wall>().setIsBehind(true);

        isBehind = true;
        terrainManager.spawnTile();
    }


}
