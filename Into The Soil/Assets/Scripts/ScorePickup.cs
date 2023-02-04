using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : PickupItem
{
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
