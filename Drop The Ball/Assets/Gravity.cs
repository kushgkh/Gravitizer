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

	public bool reset = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		arrow.SetActive (false);
		ballPInit = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			
			arrow.SetActive (true);
			//pInit = new Vector3 (470, 265, 0);
			pInit = Input.mousePosition;


			Vector3 vec = cam.ScreenToWorldPoint (pInit);
			Debug.Log (vec);
			arrow.transform.position = vec;
			//Debug.Log (Input.mousePosition);
		}
		if (Input.GetMouseButton (0)) {
			pFinal = Input.mousePosition;
			//arrow.transform.localScale = new Vector3 (Vector3.Distance (pInit, pFinal)/2, 5, 1);
			Rect arrowRect = new Rect(0,0,0,Vector3.Distance (pInit, pFinal));
			arrow.GetComponent<RectTransform> ().sizeDelta = new Vector2 (227f, Vector3.Distance (pInit, pFinal) * 10f);


			float angle = Mathf.Atan ((pFinal.y - pInit.y) / (pFinal.x - pInit.x));
			angle = angle * 180 / Mathf.PI;

			if (pFinal.x - pInit.x < 0) {
				angle += 180;
			} 
			//Debug.Log (angle);
			arrow.transform.eulerAngles = new Vector3(0,0 ,angle + 90);



		}
		if (Input.GetMouseButtonUp (0)) {
			rb.velocity = new Vector3 (5, 5, 0);

			isShot = true;
		}

		if (isShot) {
			rb.AddForce ((pFinal - pInit) * 0.03f);
		}

		if (reset) {
			arrow.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 0);
			transform.position = ballPInit;
			rb.velocity = Vector3.zero;
			isShot = false;
			reset = false;
		}
			
	}
}
