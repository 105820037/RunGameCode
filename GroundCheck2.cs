using UnityEngine;
using System.Collections;

public class GroundCheck2 : MonoBehaviour
{
    
    private Player2 player2;

    void Start()
    {
        player2 = gameObject.GetComponentInParent<Player2>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player2.grounded = true;
    }


    void OnTriggerStay2D(Collider2D col) //prevent enter twice & exit twice
    {
        player2.grounded = true;
    }


    void OnTriggerExit2D(Collider2D col)
    {
        player2.grounded = false;
    }
}
