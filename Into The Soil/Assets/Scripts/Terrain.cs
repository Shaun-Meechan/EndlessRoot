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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        StartCoroutine(behindTimer());
    }

    IEnumerator behindTimer()
    {
        yield return new WaitForSeconds(3);
        isBehind = true;
        terrainManager.spawnTile();
    }


}
