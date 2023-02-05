using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : PickupItem
{
    public GameObject getNexWaterPowerUp() { return nextWaterPowerUp; }
    public void setNextnextPowerUp(GameObject next) { nextWaterPowerUp = next; }
    GameObject nextWaterPowerUp;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setisBehind(bool value) { isBehind = value; }


    private Health playerHealth;
    private float healthIncreaseValue = 20f;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
    }

    public override type GetItemType()
    {
        return itemType;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth.UpdateHealth(healthIncreaseValue);

        Destroy(gameObject);
    }

}
