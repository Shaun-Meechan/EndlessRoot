using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : PickupItem
{
    public GameObject getNextPowerUp() { return nextPowerUp; }
    public void setNextnextPowerUp(GameObject next) { nextPowerUp = next; }
    GameObject nextPowerUp;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setisBehind(bool value) { isBehind = value; }

    private Health playerHealth;
    private RootMovement rootMovement;
    private float powerDuration = 5f;

    private void Awake()
    {
        playerHealth = FindObjectOfType<Health>();
        rootMovement = FindObjectOfType<RootMovement>();
    }

    public override type GetItemType()
    {
        return itemType;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NUTRIENTS!");
        StartCoroutine(PowerUpCoroutine());
        GameObject.Find("Game Manager").GetComponent<CustomGameManager>().StartCoroutine(PowerUpCoroutine());
        setisBehind(true);
    }

    IEnumerator PowerUpCoroutine()
    {
        playerHealth.healthCanBeDrained = false;
        playerHealth.healthBar.color = Color.green;
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        rootMovement.SetFXColor(Color.green);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(powerDuration);

        //After we have waited 5 seconds
        playerHealth.healthCanBeDrained = true;
        playerHealth.healthBar.color = new Color(0.8705883f, 0.9215687f, 0.9686275f, 1f);
        rootMovement.SetFXColor(rootMovement.DefualtColor);
    }
}
