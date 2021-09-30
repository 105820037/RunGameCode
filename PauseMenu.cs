using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;


	// Use this for initialization
	void Start () 
	{
		PauseUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("pause")) 
		{
			paused = !paused;
		}
		if (paused) 
		{
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}
		if (!paused) 
		{
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}


	public void Resume()
	{
		paused = false;
	}


	public void Restart()
	{
		//Application.LoadLevel(Application.LoadedLevel); no more working
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


	public void MainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}


	public void Quit()
	{
		Application.Quit ();
	}
}
