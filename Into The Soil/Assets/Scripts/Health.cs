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

    private CameraController cameraController;

    private void Start()
    {
        currentHealth = maxHealth;
        cameraController = FindObjectOfType<CameraController>();
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
        currentHealth -= healthDecreasedPerSecond * Time.deltaTime;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0f)
        {
            GameObject.Find("TerrainManager").GetComponent<TerrainManager>().showAlltiles();
            cameraController.reverse();
        }
    }
}
