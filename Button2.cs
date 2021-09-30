using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject redpull;
    public GameObject triger;
    bool coin = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (redpull.active = true)
        {
            if (!coin)
            {
                triger.SetActive(true);
                coin = true;
            }
        }
    }
}
