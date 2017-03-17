using UnityEngine;
using System.Collections;

public class GravityFlip : MonoBehaviour {
	public GameObject Ball;
	public Camera cam;
	bool hit = false;
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
			
			if (!hit) {
				Gravity.gravity *= -1;
				StartCoroutine (wait ());
			}

		
		}
		
	}

	IEnumerator wait()
	{
		hit = true;
		float n = cam.transform.eulerAngles.z;

		Gravity.pause = true;
		for (int i = 0; i < 180; i+=3)
		{
			yield return new WaitForSeconds(0.0001f);
			cam.transform.eulerAngles = new Vector3(0,0 , n + i);
		}
		Gravity.pause = false;
		yield return new WaitForSeconds (0.4f);
		hit = false;


	}

}
