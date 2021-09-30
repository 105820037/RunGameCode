using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backscene : MonoBehaviour {
    public bool player1ok = false;
    public bool player2ok = false;

    private void Update()
    {
        if (player1ok && player2ok)
        {
            loadnext();
        }
    }
    // Use this for initialization
    void loadnext()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player1ok = true;
        }
        if (col.gameObject.tag == "Player2")
        {
            player2ok = true;
        }
    }
}
