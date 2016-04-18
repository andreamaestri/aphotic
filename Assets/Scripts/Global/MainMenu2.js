#pragma strict

	function QuitGame () {
		Debug.Log (" Game is doing what is meant to");
		Application.Quit ();
		}
	function NewGame () {
		Application.LoadLevel ("character select");
		}
	function LoadGame () {
		Application.LoadLevel ("Load Level");
		}
	function Continue () {
		Application.LoadLevel ("continue");
		}
	function settings () {
		Application.LoadLevel ("setting");
	    }
	function back () {
	    Application.LoadLevel ("game menu");
	}
