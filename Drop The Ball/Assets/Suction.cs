using UnityEngine;
using System.Collections;

public class Suction : MonoBehaviour {

	public GameObject ball;
	public float d;
	Vector3 initPos;
	public GameObject explosion;

	float t=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance (ball.transform.position, transform.position) < d) {
			if (!Gravity.Suck) {
				initPos = ball.transform.position;
			}
			Gravity.Suck = true;
			//Debug.Log (Vector3.Distance (ball.transform.position, transform.position));
			if (t < 1) {
				ball.transform.position = Vector3.Lerp (initPos, transform.position, t);
				t +=  2 * Time.deltaTime;
			} else {
				Debug.Log ("yo");
				Gravity.Suck = false;
				explosion.SetActive (true);
				ball.transform.position = new Vector3 (-100, -100, 50);
				t = 0;
			}
		}
		if (Input.GetKeyDown ("space")) {
			explosion.SetActive (false);
			
		}

			

	}
}
