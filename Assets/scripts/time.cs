using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour {


	// Update is called once per frame
	void Start () {
        if (Time.timeScale > 0f)
        {
            Time.timeScale = 0f;
        }
	}
}
