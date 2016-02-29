using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ExitClickHandler : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Application.Quit();
		}
	}
}