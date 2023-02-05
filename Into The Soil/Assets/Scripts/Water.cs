using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : PickupItem
{

    private Health playerHealth;
    private float healthIncreaseValue = 20f;

    [SerializeField] private GameObject idleAnimation;
    [SerializeField] private GameObject collectAnimation;

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
        idleAnimation.SetActive(false);
        collectAnimation.SetActive(true);

        Destroy(gameObject, 1f);
    }


}
