using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public bool isCollide = false;
	public string labelText;

	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Player" && gameObject.tag == "Pistol")
        {
            isCollide = true;
            labelText = "Press E to pick up pistol.";
        }
        
	}


	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			isCollide = false;
		}
    }


	void OnGUI()
	{
		if (isCollide ) 
		{
			GUI.Box (new Rect (Screen.width/2-100, Screen.height - 50, 200, 25), (labelText));
		}
	}
}
