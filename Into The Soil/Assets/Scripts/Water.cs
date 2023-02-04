using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : PickupItem
{
    public override type GetItemType()
    {
        return itemType;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateHealth(GameObject player)
    {

    }
}
