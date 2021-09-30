using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeY;
	public float smoothTimeX;
    Camera camera;
    public GameObject player;
    public GameObject player2;

	public bool bounds;

	public Vector3 maxCameraPos;
	public Vector3 minCameraPos;

	// Use this for initialization
	void Start () 
	{
        camera = gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float posX = Mathf.SmoothDamp (transform.position.x, (player.transform.position.x + player2.transform.position.x)/2, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, (player.transform.position.y + player2.transform.position.y)/2, ref velocity.y, smoothTimeY);
		transform.position = new Vector3 (posX, posY, transform.position.z);
        
		if (bounds) 
		{
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x), 
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				transform.position.z);
		}
	}
}
