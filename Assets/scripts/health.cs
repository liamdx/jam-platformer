using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public int currentHealth;

    public int initHealth;

    public GameObject deathObject;

    private void Start()
    {
        currentHealth = initHealth;
    }
    private void LateUpdate()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            kill();
        }
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

    public void kill()
    {
        GameObject death = Instantiate(deathObject, transform);
        death.transform.position = transform.position;
        Invoke("destroyThis", 1.0f);
    }

    public void destroyThis()
    {
        DestroyImmediate(this.gameObject);
    }

}
