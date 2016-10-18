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
		
		}
		
	}

}
