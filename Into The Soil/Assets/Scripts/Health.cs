using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float maxHealth = 100f;
    private float currentHealth;
    private float healthDecreasedPerSecond = 2f;

    [SerializeField] public Image healthBar;

    private CameraController cameraController;

    public bool healthCanBeDrained;

    private void Start()
    {
        currentHealth = maxHealth;
        cameraController = FindObjectOfType<CameraController>();
        healthCanBeDrained = true;
    }

    public float GetHealth()
    {
        return currentHealth;
    }
    
    public void UpdateHealth(float change)
    {
        currentHealth += change;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    

    private void Update()
    {
        Debug.Log("healthIsDraining: " + healthCanBeDrained);

        if (healthCanBeDrained)
        {
            currentHealth -= healthDecreasedPerSecond * Time.deltaTime;
        }
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0f)
        {
            cameraController.reverse();
        }
    }
}
