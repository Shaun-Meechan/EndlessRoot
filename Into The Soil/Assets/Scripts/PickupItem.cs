using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    public enum type
    {
        water,
        nutrition,
    }

    public type itemType;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.LogError("This is " + itemType.ToString());
            UpdateHealth(other.gameObject);
        }
    }

    public abstract type GetItemType();

    public abstract void UpdateHealth(GameObject player);
}
