using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearedTextAnimatio : MonoBehaviour {
	public Text cleared;
	string word = "CLEARED";
	int count=0;
	// Use this for initialization
	void Start () {
		StartCoroutine (wait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds (.15f);
		cleared.text += word[count].ToString();
		count++;
		if (count < word.Length) {
			StartCoroutine (wait ());
		}
	}
}
