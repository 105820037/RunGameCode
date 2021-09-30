using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

    [SerializeField]
    int moveSpeed = 250;

	void Update () 
	{
        transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
        //GetComponent<Rigidbody2D>().AddForce(transform.rotation * new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
        Destroy (gameObject, 2);
	}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }*/
}
