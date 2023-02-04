
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutritionPowerUp : MonoBehaviour
{
    public GameObject getNextPowerUp() { return nextPowerUp; }
    public void setNextnextPowerUp(GameObject next) { nextPowerUp = next; }
    GameObject nextPowerUp;

    bool isBehind = false;
    public bool getIsBehind() { return isBehind; }
    public void setisBehind(bool value) { isBehind = value; }

}
