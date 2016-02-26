using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public GameObject LoadingScene;
	public Image LoadingBar;

	public void LoadLevel ()
	{
		StartCoroutine (LevelCoroutine ());
	}
	IEnumerator LevelCoroutine ()
	{
		LoadingScene.SetActive (true);
		AsyncOperation async = SceneManager.LoadSceneAsync (1);

		while (!async.isDone) {
			LoadingBar.fillAmount = async.progress / 0.9f;
			yield return null;
		}
	}
}