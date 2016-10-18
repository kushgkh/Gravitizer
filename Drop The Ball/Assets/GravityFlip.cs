using UnityEngine;
using System.Collections;

public class GravityFlip : MonoBehaviour {
	public GameObject Ball;
	public Camera cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision)
	{

		if(collision.collider.gameObject.Equals(Ball))
		{
			Gravity.gravity *= -1;
			/*
			Gravity.pause = true;

			

			float deltaAngle = ((gravityAngle + 90) ) * Time.deltaTime;

			cam.transform.eulerAngles= new Vector3(0,0 ,cam.transform.eulerAngles.z + deltaAngle);


			if (Mathf.Abs(cam.transform.eulerAngles.z - gravityAngle - 90) < 2) {
				rb.velocity = new Vector3 (50, 50, 0);

			}
			*/

		}
		
	}

}
