using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int minHealth;
    [SerializeField] int _health;
    public int health 
    {
        get { return _health; }
        private set { _health = value;} 
    }

    public int maxSap;
    public int minSap;
    [SerializeField] int _sap;
    public int sap 
    {
        get { return _sap; }
        private set { _sap = value;}
    }

    public void ReduceSap()
    {
        if (sap <= 0)
        {
            health--;
        }
        else
        {
            sap--;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
