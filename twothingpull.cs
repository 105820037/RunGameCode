using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twothingpull : MonoBehaviour
{
    public GameObject redpullclose;
    public GameObject redpullopen;
    public GameObject first_thing;
    public GameObject second_thing;

    public bool check;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            first_thing.SetActive(true);
            second_thing.SetActive(false);
            redpullclose.SetActive(false);
            redpullopen.SetActive(true);
            check = false;
        }
    }
}
