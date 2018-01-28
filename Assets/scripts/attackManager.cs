using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackManager : MonoBehaviour
{

    public GameObject[] attacks;
    int attack01;
    int attack02;

    private GameObject currentAttackObject01;
    private attack currentAttack01;
    private GameObject currentAttackObject02;
    private attack currentAttack02;

    // Use this for initialization
    private void Start()
    {
        attack01 = 0;
        attack02 = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Attack01();
        Attack02();
    }

    private void Attack01()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentAttackObject01 = GameObject.Instantiate(attacks[attack01]);
            currentAttack01 = currentAttackObject01.GetComponent<attack>();
            currentAttack01.setCaster(this.gameObject);
            currentAttack01.Attack();
        }
    }

    private void Attack02()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            currentAttackObject02 = GameObject.Instantiate(attacks[attack02]);
            currentAttack02 = currentAttackObject02.GetComponent<attack>();
            currentAttack02.setCaster(this.gameObject);
            currentAttack01.Attack();
        }
    }


}
