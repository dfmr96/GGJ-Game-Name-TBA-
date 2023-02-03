using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Slider sapBar;
    [SerializeField] PlayerStats playerStats;

    private void Start()
    {
        healthBar.maxValue = playerStats.maxHealth;
        healthBar.minValue = playerStats.minHealth;

        sapBar.maxValue = playerStats.maxSap;
        sapBar.minValue = playerStats.minSap;
    }
    private void Update()
    {
        healthBar.value = playerStats.health;
        sapBar.value = playerStats.sap;
    }
}
