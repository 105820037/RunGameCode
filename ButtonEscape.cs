using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEscape : MonoBehaviour {
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject triger;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        triger.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
            redpullclose.SetActive(true);
            redpullopen.SetActive(false);
            triger.SetActive(false);
    }
}
