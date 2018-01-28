using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int currentHealth;

    public int initHealth;

    private void Start()
    {
        currentHealth = initHealth;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void doDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void addHealth(int addition)
    {
        currentHealth += addition;
    }

    public void restoreHealth()
    {
        currentHealth = initHealth;
    }


}
