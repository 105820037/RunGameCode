using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
    public GameObject redpullopen;
    public bool check = false;
    // Use this for initialization
    void Start ()
    {
        Animation animation = GetComponent<Animation>();
        animation.CrossFade("NORMAL");
    }
	
	// Update is called once per frame
	void Update () {
        if (redpullopen.activeSelf)
        {
            Animation animation = GetComponent<Animation>();
            animation.CrossFade("trigger");
            check = true;
        }
        if (check)
        {
            if (!redpullopen.activeSelf)
            {
                Animation animation = GetComponent<Animation>();
                animation.CrossFade("Noaction2");
            }
        }
    }
}
