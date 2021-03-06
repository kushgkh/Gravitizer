﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Suction : MonoBehaviour {

	public GameObject ball;
	public float d;
	Vector3 initPos;
	public GameObject explosion;
	public GameObject win;

	public float wormHoleStrength=1;
	float t=0;

	public GameObject wormholeCollapse;

	bool collapsed=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance (ball.transform.position, transform.position) < d) {
			
			//Gravity.Suck = true;
			if (Vector3.Distance (ball.transform.position, transform.position) < 20 && !collapsed) { //if the ball gets sucked in
				//explosion.SetActive (true);
				wormholeCollapse.GetComponent<Animator>().SetBool("collapse",true);
				ball.GetComponent<SpriteRenderer> ().enabled = false;
				ball.GetComponent<Rigidbody> ().velocity = Vector3.zero;
				win.SetActive (true);
				collapsed = true;
				StartCoroutine (wait ());
				//Gravity.Suck = false;
			} else {
				ball.GetComponent<Rigidbody> ().AddForce (wormHoleStrength * (transform.position - ball.transform.position) / Vector3.Distance (ball.transform.position, transform.position));
			}
		}
		if (Input.GetKeyDown ("space")) {
			explosion.SetActive (false);
			
		}

			

	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}

}
