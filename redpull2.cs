using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redpull2 : MonoBehaviour {
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject triger;
    public bool check;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            check = true;
        }
        if (other.gameObject.tag == "Player2")
        {
            check = true;
        }
        if (other.gameObject.tag == "triger"&&check)
        {
            redpullclose.SetActive(true);
            redpullopen.SetActive(false);
            check = false;
        }  
        
    }
}
