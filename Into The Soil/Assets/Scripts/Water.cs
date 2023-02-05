using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : PickupItem
{

    [SerializeField]
    private GameObject idleAnimation;

    [SerializeField]
    private GameObject collectAnimation;

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
        StartCoroutine(WaterCollectCoroutine());
    }

    IEnumerator WaterCollectCoroutine()
    {
        playerHealth.UpdateHealth(healthIncreaseValue);
        idleAnimation.SetActive(false);
        collectAnimation.SetActive(true);
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);

        //After we have waited 5 seconds
        //Destroy(gameObject);
        setisBehind(true);
    }

}
