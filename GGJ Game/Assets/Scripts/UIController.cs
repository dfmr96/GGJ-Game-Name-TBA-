using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] PlayerStats playerStats;

    private void Start()
    {
        healthBar.maxValue = playerStats.maxHealth;
        healthBar.minValue = playerStats.minHealth;
    }
    private void Update()
    {
        healthBar.value = playerStats.health;
    }
}
