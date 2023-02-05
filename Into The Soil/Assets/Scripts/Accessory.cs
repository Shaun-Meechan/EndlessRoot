using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : PickupItem
{
    public enum accessoryType
    {
        sunglasses,
        chain,
        hat,
    }

    Score score;
    public accessoryType type;
    TreeDresser dresser;


    private void Awake()
    {
        score = FindObjectOfType<Score>();
        dresser = FindObjectOfType<TreeDresser>();
    }

    public override type GetItemType()
    {
        return itemType;
    }

    public accessoryType GetAccessoryType()
    {
        return type;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        score.scoreValue += 500f;
        dresser.RegisterAccessoryCollected(GetAccessoryType());
        Destroy(gameObject);
    }

}
