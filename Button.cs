using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject triger;
    public GameObject triger2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
            redpullclose.SetActive(false);
            redpullopen.SetActive(true);
            triger.SetActive(true);
            triger2.SetActive(false);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        redpullclose.SetActive(true);
        redpullopen.SetActive(false);
        triger.SetActive(false);
        triger2.SetActive(true);
    }
}
