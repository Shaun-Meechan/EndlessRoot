using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    private float healthDecreasedPerSecond = 2f;

    [SerializeField] private Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
    
    public void UpdateHealth(float change)
    {
        currentHealth += change;

    }

    /*
    public void SetBarSize(float sizeNormalized)
    {
        healthBar.transform.localScale = new Vector3(sizeNormalized, 1f);
    }
    */

    private void Update()
    {
        currentHealth -= healthDecreasedPerSecond * Time.deltaTime;
        //SetBarSize(currentHealth/100);
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
