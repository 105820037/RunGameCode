using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redpull4 : MonoBehaviour {
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject triger;
    public GameObject triger2;
    public bool check = true;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (redpullopen.activeSelf && check)
        {
            StartCoroutine("TIMERECODE");
            check = false;
        }
	}
    IEnumerator TIMERECODE()
    {
        yield return new WaitForSeconds(5);
        redpullclose.SetActive(true);
        triger.SetActive(false);
        triger2.SetActive(false);
        check = true;
        redpullopen.SetActive(false);
    }
}
