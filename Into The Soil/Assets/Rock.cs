using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject getNextRock() { return nextRock; }
    public void setNextRock(GameObject next) { nextRock = next; }
    GameObject nextRock;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setIsBehind(bool value) { isBehind = value; }

}
