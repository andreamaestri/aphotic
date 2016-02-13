using UnityEngine;
using System.Collections;

public class StartLevel : MonoBehaviour 
{
	public void LoadScene(string name)
	{
		Application.LoadLevel (name);
	}   
}