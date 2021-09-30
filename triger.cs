using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger : MonoBehaviour {
    
    public GameObject redpullopen;
    public bool check=false;
    // Use this for initialization
    void Start () {
        Animation animation = GetComponent<Animation>();
        animation.CrossFade("NOACTION");
    }
	
	// Update is called once per frame
	void Update () {
        if  (redpullopen.activeSelf)
        {
            Animation animation = GetComponent<Animation>();
            animation.CrossFade("intrigue");
            check = true;
        }
        if (check)
        {
            if (!redpullopen.activeSelf)
            {
                Animation animation = GetComponent<Animation>();
                animation.CrossFade("normalground");
            }
        }
    }
}
