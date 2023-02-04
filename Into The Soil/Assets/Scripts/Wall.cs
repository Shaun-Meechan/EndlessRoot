using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject getNextWall() { return nextWall; }
    public void setNextWall(GameObject next) { nextWall = next; }
    GameObject nextWall;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setIsBehind(bool value) { isBehind = value; }

}
