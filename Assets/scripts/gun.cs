using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {

    public GameObject bullet;
    public Transform barrel;
    public float forceMultipler;

    private void Shoot()
    {
        GameObject currentBullet = GameObject.Instantiate(bullet, barrel);
        Rigidbody rib = currentBullet.GetComponent<Rigidbody>();
        Vector3 bulletForce = barrel.transform.forward * forceMultipler;
        rib.AddForce(bulletForce);
    }

    
}
