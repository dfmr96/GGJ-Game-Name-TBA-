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

    public void ReduceSap()
    {
        health--;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <=0)
        {
            GameManager.sharedInstance.RespawnPlayer(this.gameObject);
        }
    }

    public void RestoreHealthPoints(int point)
    {
        health += point;
    }

    public void FullHealthRestore()
    {
        health = maxHealth;
    }
}
