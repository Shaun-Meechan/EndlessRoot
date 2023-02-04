using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : PickupItem
{
    public GameObject getNextPowerUp() { return nextPowerUp; }
    public void setNextnextPowerUp(GameObject next) { nextPowerUp = next; }
    GameObject nextPowerUp;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setisBehind(bool value) { isBehind = value; }

    void AddScore()
    {
        GameObject.Find("Score").GetComponent<Score>().scoreValue += 10;
        Destroy(gameObject);
    }

    public override type GetItemType()
    {
        return itemType;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("This is " + itemType.ToString());
        AddScore();
    }

    public override void UpdateHealth(GameObject player)
    {
        throw new System.NotImplementedException();
    }

}
