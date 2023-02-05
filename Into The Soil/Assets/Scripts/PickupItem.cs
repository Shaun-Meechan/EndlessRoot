using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupItem : MonoBehaviour
{
    public enum type
    {
        water,
        accessory,
        nutrients,
    }

    public type itemType;

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.LogError("This is " + itemType.ToString());
            
    //    }
    //}

    public abstract type GetItemType();

}
