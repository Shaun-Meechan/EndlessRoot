using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Health playerHealth;
    private float healthDecreaseValue = -30f;

    public GameObject getNextEnemy() { return nextEnemy; }
    public void setNextEnemy(GameObject next) { nextEnemy = next; }
    GameObject nextEnemy;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setIsBehind(bool value) { isBehind = value; }

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collision");
        if(collision.gameObject.CompareTag("Player"))
        {
            
            GetComponent<EnemyMovement>().canMove = false;
            setIsBehind(true);
            //collision.gameObject.GetComponent<RootMovement>().playerDied();
            //GameObject.Find("TerrainManager").GetComponent<TerrainManager>().showAlltiles();
            //Camera.main.GetComponent<CameraController>().reverse();
            
            playerHealth.UpdateHealth(healthDecreaseValue);
        }
        //Damage player
        
    }
}
