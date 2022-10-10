using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    public void SetMaxHealth(int newMaxHealth) {
        maxHealth = newMaxHealth;
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public void SetCurrentHealth(int newCurrentHealth) {
        currentHealth = newCurrentHealth;
    }

    public void TakeDamage() {
        TakeDamage(1);
    }

    public virtual void TakeDamage(int d) {
        currentHealth -= d;
        if (currentHealth <= 0) {
            Die();
        }
    }

    public abstract void Die();
}
