#pragma strict

    var sound : AudioSource;
	function GameVolume (vol : float) {
		sound.volume = vol;
		}
	function AA0 () {
		QualitySettings.antiAliasing = 0;
		Debug.Log ("AA0");
		}
	function AA2 () {
		QualitySettings.antiAliasing = 2;
		Debug.Log ("2AA");
		}
	function AA4 () {
		QualitySettings.antiAliasing = 4;
		Debug.Log ("4AA");
		}
	function AA8 () {
		QualitySettings.antiAliasing = 8;
		Debug.Log ("8AA");
		}
	function FastQuality () {
	    QualitySettings.SetQualityLevel (1);
	    Debug.Log ("Fast");
	}
	function GoodQuality () {
	    QualitySettings.SetQualityLevel (2);
	    Debug.Log ("Good");
	}
	function FastestQuality () {
	    QualitySettings.SetQualityLevel (0);
	    Debug.Log ("Fastest");
	}
	function FantasticQuality () {
	    QualitySettings.SetQualityLevel (4);
	}