using UnityEngine;
using System.Collections;

public class QuitBtn : MonoBehaviour {
	

	// Update is called once per frame
	void Update() {
		if (Input.GetKey ("escape"))
			Application.Quit ();
	}
	public void ClickExit()

	{
		Application.Quit();
		
		}
	}