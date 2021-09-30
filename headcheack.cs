using UnityEngine;
using System.Collections;
public class headcheack : MonoBehaviour {


    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "triger")
        {
            player.headed = true;
        }
        else if (col.gameObject.tag == "Player2")
        {
            player.headed = true;
        }
    }


    void OnTriggerStay2D(Collider2D col) //prevent enter twice & exit twice
    {
        if (col.gameObject.tag == "triger")
        {
            player.headed = true;
        }
        else if (col.gameObject.tag == "Player2")
        {
            player.headed = true;
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
            player.headed = false;
    }
}
