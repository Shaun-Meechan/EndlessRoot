using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public static class RootDataKeeper
{

    [SerializeField]
    private static int maxRoots = 10;

    private static List<SpriteShape> roots = new List<SpriteShape>();

    public static void StoreShape(SpriteShape newRoots)
    {
        if (newRoots != null)
        {
            if(roots.Count < maxRoots)
                roots.Add(newRoots);
            else
            {
                roots.RemoveAt(0);
                roots.Add(newRoots);
            }
        }
    }

    public static int GetNumOfShape()
    {
        return roots.Count;
    }
}
