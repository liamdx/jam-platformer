using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthText : MonoBehaviour {

    public GameObject healthParent;

    private Text text;
    private health thisHealth;
    private int currentHealth;

    private void Start()
    {
        text = GetComponent<Text>();
        thisHealth = healthParent.GetComponent<health>();
        currentHealth = thisHealth.getHealth();
    }

    private void LateUpdate()
    {
        currentHealth = thisHealth.getHealth();
        text.text =  currentHealth.ToString();
    }
}
