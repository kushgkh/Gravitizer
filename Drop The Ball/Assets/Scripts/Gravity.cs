using UnityEngine;
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
	public static Vector3 gravity;
	public static bool pause  = false;
	Vector3 ballVelocity;
	public GameObject velocityArrow;
	public float velocityMagnitude;


	public GameObject dot;
	Vector3 dotUpdatePosition;
	public float dotDistance = 1;
	public GameObject dotParent;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		arrow.SetActive (false);
		ballPInit = transform.position;
		dotUpdatePosition = ballPInit;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			reset = true;
		}
		if (!isShot && !spinning) {
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
				angle += 90;
				gravityAngle = angle;
				//Debug.Log (angle);
				arrow.transform.eulerAngles = new Vector3(0,0 ,angle);

			}
			if (Input.GetMouseButtonUp (0)) {
				gravity = (pFinal - pInit) * 0.3f;

				gravity = gravity.normalized * 30;

				if (gravity.magnitude > 0)
				{
					spinning = true;
				}
				else
				{
					arrow.SetActive (false);
				}



			}
			
		}

		if (!pause) {
			ballVelocity = rb.velocity;
		}
		else
		{
			ballVelocity = Vector3.zero;
		}


		if (spinning) {
			Debug.Log (gravityAngle);

			if (gravityAngle < 180)
			{
				cam.transform.eulerAngles= new Vector3(0,0 ,cam.transform.eulerAngles.z + 3);
			}
			else
			{
				cam.transform.eulerAngles= new Vector3(0,0 ,cam.transform.eulerAngles.z - 3);
			}

			if (Mathf.Abs(cam.transform.eulerAngles.z - (gravityAngle)) < 5) {



				float y= Mathf.Cos (velocityArrow.transform.rotation.eulerAngles.z * Mathf.PI / 180.0f);
				float x = -Mathf.Sin (velocityArrow.transform.rotation.eulerAngles.z * Mathf.PI / 180.0f);	


			

				rb.velocity = new Vector3 (x * velocityMagnitude , y * velocityMagnitude, 0);
				spinning = false;
				isShot = true;

			}
		}
		//Debug.Log (Suck);

		if (isShot && !Suck) {

			rb.AddForce (gravity);
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
			GetComponent<SpriteRenderer> ().enabled = true;
			isShot = false;
			reset = false;
		}
			

		if (Vector3.Distance (dotUpdatePosition, transform.position) > dotDistance) {
			GameObject dt = Instantiate (dot, transform.position, Quaternion.identity) as GameObject;
			dt.transform.SetParent (dotParent.transform);
			dotUpdatePosition = transform.position;

		}
	}
}
