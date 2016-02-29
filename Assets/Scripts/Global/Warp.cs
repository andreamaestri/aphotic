using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform Warp_target;

	IEnumerator OnTriggerEnter2D (Collider2D other){

		Debug.Log ("OBJECT COLLIDED");
	
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		Debug.Log ("Pre Fade Out");
	
		yield return StartCoroutine (sf.FadeToBlack () );

		Debug.Log ("Update Player Position");

		other.gameObject.transform.position = Warp_target.position;
		Camera.main.transform.position = Warp_target.position;

		yield return StartCoroutine (sf.FadeToClear ());

		Debug.Log ("Fade Is Complete");
}
}