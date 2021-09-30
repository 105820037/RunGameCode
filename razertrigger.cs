using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class razertrigger : MonoBehaviour {
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "razer")
        {
            redpullclose.SetActive(false);
            redpullopen.SetActive(true);
            triger.SetActive(true);
            triger2.SetActive(false);
        }
    }
}
