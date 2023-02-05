using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisability : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Debug.Log("Killed player");
        GameObject.Find("Health Bar").GetComponent<Health>().killPlayer();
    }

}
