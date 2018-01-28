using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    public int damage;
    public float aoe;
    private ParticleSystem attackParticleSystem;
    private GameObject caster;



    private void Start()
    {
        attackParticleSystem = GetComponent<ParticleSystem>();
        attackParticleSystem.Play();
        if (damage <= 0)
        {
            damage = 10;
        }

        if (aoe <= 0)
        {
            aoe = 10;
        }
        Invoke("destroySelf", 1.5f);
    }

    private void LateUpdate()
    {
        if (caster != null)
        {
            transform.position = caster.transform.position;
        }
    }

    public void Attack(GameObject target)
    {
        GameObject[] attackableEntities = attackShouldDamage();
        for (int i = 0; i < attackableEntities.Length; i++)
        {
            if (target == attackableEntities[i])
            {
                target.GetComponent<health>().doDamage(damage);
            }
            i++;
        }
    }

    public void Attack()
    {
        /*
        GameObject[] attackableEntities = attackShouldDamage();
        health currentHealth;

        if(attackableEntities[0] != null)
        {
            for (int i = 0; i < attackableEntities.Length - 1; i++)
            {
                Debug.Log(attackableEntities[i].tag);
                currentHealth = attackableEntities[i].GetComponent<health>();
                currentHealth.doDamage(damage);
                i++;
            }
        }
        */

        findAndAttack();
        
    }

    void destroySelf()
    {
        Destroy(this.gameObject);
    }

    public void setCaster(GameObject newCaster)
    {
        caster = newCaster;
    }

    //Sphere cast round player for AOE attack
    //if current entity is not of type player, entity can be attacked
    //returns array of attackable enemies

    private GameObject[] attackShouldDamage()
    {
        GameObject[] entities = new GameObject[32];
        health currentHealth;
        Collider[] colliders = Physics.OverlapSphere(caster.transform.position, aoe);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] != null)
            {
                currentHealth = colliders[i].GetComponent<health>();
                if (currentHealth != null)
                {
                    entities[i] = colliders[i].gameObject;
                }
            }
            i++;
        }
        return entities;
    }

    private void findAndAttack()
    {
        Collider[] colliders = Physics.OverlapSphere(caster.transform.position, aoe);
        int i = 0;

        if(colliders[0] != null)
        {
            while (i < colliders.Length)
            {
                if(colliders[i].gameObject == caster)
                {
                    i++;
                }
                else if (colliders[i].GetComponent<health>() != null)
                {
                    colliders[i].SendMessage("doDamage", damage);
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
        
    }
}
