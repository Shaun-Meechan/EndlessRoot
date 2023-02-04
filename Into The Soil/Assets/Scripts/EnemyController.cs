using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject getNextEnemy() { return nextEnemy; }
    public void setNextEnemy(GameObject next) { nextEnemy = next; }
    GameObject nextEnemy;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setIsBehind(bool value) { isBehind = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collision");
        //Damage player
        GetComponent<EnemyMovement>().canMove = false;
        setIsBehind(true);
    }
}
