using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    [SerializeField] private Image foregroundImage; // The foreground (fill) image
    [SerializeField] private float maxHealth = 100f;

    void Update()
    {
        // Calculate the percentage of health
        float healthPercent = powerUi.power / maxHealth;

        // Clamp the value to avoid errors if currentHealth goes above maxHealth or below 0
        healthPercent = Mathf.Clamp01(healthPercent);

        // Set the fill amount of the foreground image
        foregroundImage.fillAmount = healthPercent;
    }
}
