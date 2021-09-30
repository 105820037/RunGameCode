using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redpull3 : MonoBehaviour {
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject triger;
    public GameObject triger2;
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
        if (other.gameObject.tag == "triger" && check)
        {
            redpullclose.SetActive(false);
            redpullopen.SetActive(true);
            triger.SetActive(true);
            triger2.SetActive(true);
            check = false;
        }

    }

}
