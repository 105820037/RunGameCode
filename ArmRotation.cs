using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

    [SerializeField]
	int plusAngle = 0;

	void Update () 
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		diff.Normalize ();
		float rotZ = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + plusAngle);
	}
}
