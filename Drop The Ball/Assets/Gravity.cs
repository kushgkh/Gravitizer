﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gravity : MonoBehaviour {
	Rigidbody rb;
	Vector3 pInit;
	Vector3 pFinal;
	public GameObject arrow;
	bool isShot = false;
	Vector3 ballPInit;
	public Camera cam;
	Vector3 vec;
	public bool reset = false;
	bool spinning = false;
	float initAngle = 0;
	float gravityAngle;
	public static bool Suck = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		arrow.SetActive (false);
		ballPInit = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			reset = true;
		}
		if (!isShot) {
			if (Input.GetMouseButtonDown (0)) {

				arrow.SetActive (true);
				//pInit = new Vector3 (470, 265, 0);
				pInit = Input.mousePosition;


				vec = cam.ScreenToWorldPoint (pInit);
				Debug.Log (vec);
				arrow.transform.position = vec;
				//Debug.Log (Input.mousePosition);
			}
			if (Input.GetMouseButton (0)) {
				pFinal = Input.mousePosition;
				//arrow.transform.localScale = new Vector3 (Vector3.Distance (pInit, pFinal)/2, 5, 1);
				Rect arrowRect = new Rect(0,0,0,Vector3.Distance (pInit, pFinal));
				arrow.GetComponent<RectTransform> ().sizeDelta = new Vector2 (227f, Vector3.Distance (pInit, pFinal) * 10f);
				arrow.transform.position = new Vector3 (vec.x, vec.y, 0);

				float angle = Mathf.Atan ((pFinal.y - pInit.y) / (pFinal.x - pInit.x));
				angle = angle * 180 / Mathf.PI;

				if (pFinal.x - pInit.x < 0) {
					angle += 180;
				} 
				gravityAngle = angle;
				//Debug.Log (angle);
				arrow.transform.eulerAngles = new Vector3(0,0 ,angle + 90);



			}
			if (Input.GetMouseButtonUp (0)) {
				




				spinning = true;
			}
			
		}

		if (spinning) {
			float deltaAngle = ((gravityAngle + 90) - 0) * Time.deltaTime;
			
			cam.transform.eulerAngles= new Vector3(0,0 ,cam.transform.eulerAngles.z + deltaAngle);
		

			if (Mathf.Abs(cam.transform.eulerAngles.z - gravityAngle - 90) < 2) {
				rb.velocity = new Vector3 (5, 5, 0);
				spinning = false;
				isShot = true;
			}
		}
		//Debug.Log (Suck);

		if (isShot && !Suck) {
			rb.AddForce ((pFinal - pInit) * 0.03f);
		}
		if (Suck) {
			rb.velocity = Vector3.zero;
			
		}

		if (reset) {
			Suck = false;
			arrow.transform.position = new Vector3 (0, 0, 0);
			arrow.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			transform.position = ballPInit;
			rb.velocity = Vector3.zero;
			cam.transform.eulerAngles = Vector3.zero;
			isShot = false;
			reset = false;
		}
			
	}
}
