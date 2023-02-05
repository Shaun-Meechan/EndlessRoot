using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDresser : Accessory
{
    [SerializeField] public GameObject sunglasses;
    [SerializeField] public GameObject chain;
    [SerializeField] public GameObject hat;

    // Start is called before the first frame update
    void Start()
    {
        sunglasses.SetActive(false);
        chain.SetActive(false);
        hat.SetActive(false);
    }

    public void RegisterAccessoryCollected(accessoryType type)
    {
        if (type == accessoryType.sunglasses )
        {
            sunglasses.SetActive(true);
        }
        if (type == accessoryType.chain)
        {
            chain.SetActive(true);
        }
        if (type == accessoryType.hat)
        {
            hat.SetActive(true);
        }
    }
}
