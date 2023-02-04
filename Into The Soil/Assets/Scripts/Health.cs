using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth = 100f;

    public float GetHealth()
    {
        return currentHealth;
    }
    
    public void UpdateHealth(float change)
    {
        currentHealth += change;

    }
}
