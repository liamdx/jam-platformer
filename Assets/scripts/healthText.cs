using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthText : MonoBehaviour {

    public GameObject healthParent;

    private TextMesh text;
    private health thisHealth;
    private int currentHealth;

    private void Start()
    {
        text = GetComponent<TextMesh>();
        thisHealth = healthParent.GetComponent<health>();
        currentHealth = thisHealth.getHealth();
    }

    private void LateUpdate()
    {
        currentHealth = thisHealth.getHealth();
        text.text =  currentHealth.ToString();
    }
}
