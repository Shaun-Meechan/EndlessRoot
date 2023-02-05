using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public static class RootDataKeeper
{

    [SerializeField]
    private static int maxRoots = 5;

    private static List<System.Reflection.FieldInfo[]> allFields;

    private static List<Spline> roots = new List<Spline>();

    public static void StoreShape(Spline newRoots)
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

    public static void StoreField(System.Reflection.FieldInfo[] newRoots)
    {
        if (newRoots != null)
        {
            if (allFields.Count < maxRoots)
                allFields.Add(newRoots);
            else
            {
                allFields.RemoveAt(0);
                allFields.Add(newRoots);
            }
        }
    }

    public static int GetNumOfShape()
    {
        return roots.Count;
    }

    public static List<Spline> GetAllRoots()
    {
        return new List<Spline>(roots);
    }

    public static List<System.Reflection.FieldInfo[]> GetFields()
    {
        return allFields;
    }
}
