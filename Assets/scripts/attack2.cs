using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2 : MonoBehaviour {

    // Store animations/particle system 
    // Area of effect/projectile

    public int damage;
    public float aoe;
    private ParticleSystem attackParticleSystem;
    private GameObject caster;

    // Use this for initialization
    void Start ()
    {
        attackParticleSystem = GetComponent<ParticleSystem>();

        if (damage == 0)
        {
            damage = 5;
        }
	}

    //Multiple ways to start attack
    //1. play animation
    //2. attack 1 unit
    //3. attack multiple units
	
    void attack()
    {
        attackParticleSystem.Play();
    }

    void attack(GameObject target)
    {
        //play animation
        attack();
        //get targets health and do damage
        health currentTargetHealth = target.GetComponent<health>();
        currentTargetHealth.doDamage(damage);
    }

    void attack(GameObject[] targets)
    {
        //play animation
        attack();
        //set up health script variable
        health currentTargetHealth;
        //iterate through all entites in array
        for(int i = 0; i < targets.Length; i++)
        {
            //if target has component health
            //Do some damage
            currentTargetHealth = targets[i].GetComponent<health>();
            if(currentTargetHealth != null)
            {
                currentTargetHealth.doDamage(damage);
            }
        }
    }

    //How can we collect ALL attackable entities? 
    //Sphere cast round player for AOE attack
    //if current entity is not of type player, entity can be attacked

    private GameObject[] attackShouldDamage()
    {
        GameObject[] entites;
        entites = new GameObject[4];
        Ray currentRayCheck = new Ray();
        RaycastHit currentRayHit;
        entityManager currentEntity;
        if (Physics.SphereCast(currentRayCheck, aoe, out currentRayHit))
        {
            currentEntity = currentRayHit.collider.gameObject.GetComponent<entityManager>();
            if (currentEntity != null && currentEntity.getEntityType() != 0)
            {

            }
        }

        return entites;
    }
}
