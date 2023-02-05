using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutrients : PickupItem
{
    private Health playerHealth;
    private float powerDuration = 5f;

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
        Debug.Log("NUTRIENTS!");
        StartCoroutine(PowerUpCoroutine());
    }

    IEnumerator PowerUpCoroutine()
    {
        playerHealth.healthCanBeDrained = false;
        playerHealth.healthBar.color = Color.green;
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(powerDuration);

        //After we have waited 5 seconds
        playerHealth.healthCanBeDrained = true;
        playerHealth.healthBar.color = new Color(0.8705883f, 0.9215687f, 0.9686275f, 1f);
        Destroy(gameObject);
    }
}
