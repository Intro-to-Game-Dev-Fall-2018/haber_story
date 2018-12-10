using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {    
 
	public void OnPointerEnter( PointerEventData ped ) {
		AudioManager.i.Play("MouseOverButton");
	}
 
	public void OnPointerDown( PointerEventData ped ) {
		AudioManager.i.Play("MouseClickButton");
	}

	public void OnPointerExit(PointerEventData ped)
	{
		AudioManager.i.Play("MouseExitButton");
	}
}

