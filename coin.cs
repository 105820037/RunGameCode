using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour {
    public Text CoinText;
    public Text CoinEndText;
    public GameObject coinget;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        int i = int.Parse(CoinText.text);
        if (col.gameObject.tag == "Player")
        {
            i=i + 1;
            CoinEndText.text = i.ToString();
            CoinText.text = i.ToString();
            coinget.SetActive(false);
        }
        if (col.gameObject.tag == "Player2")
        {
            i = i + 1;
            CoinEndText.text = i.ToString();
            CoinText.text = i.ToString();
            coinget.SetActive(false);
        }
        if(col.gameObject.tag== "triger")
        {
            i = i + 1;
            CoinEndText.text = i.ToString();
            CoinText.text = i.ToString();
            coinget.SetActive(false);
        }
    }
}
