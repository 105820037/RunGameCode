using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public GameObject EndUI;
    private bool paused = false;
    bool player1ok = false;
    bool player2ok = false;

    // Use this for initialization
    void Start()
    {
        EndUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player1ok && player2ok)
        {
            paused = true;
        }
        if (paused)
        {
            EndUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            EndUI.SetActive(false);
            Time.timeScale = 1;
        }
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