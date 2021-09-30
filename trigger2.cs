using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger2 : MonoBehaviour {

    public GameObject pull;
    public GameObject trigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (pull.activeSelf)
        {
            trigger.SetActive(false);
        }
	}
}
