using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGUI : MonoBehaviour
{

	[SerializeField] private Image _characterDisplay;
	[SerializeField] private TextMeshProUGUI _dialogueDisplay;
	[SerializeField] private CanvasGroup _canvasGroup;
	
	private CharacterSet _characters;

	private void Start()
	{
		_characters = Loader.i.Characters;
	}

	private void Update()
	{
		if (Input.GetButton("Cancel"))
		{
			HideCanvas();
		}
	}

	public void DisplayCharacter(string name)
	{
		_characterDisplay.sprite = _characters.GetCharacter(name).Sprite;
		ShowCanvas();
	}
	
	public void NoCharacter()
	{
		_characterDisplay.sprite = null;
	}

	public void HideCanvas()
	{
		_canvasGroup.alpha = 0f;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.interactable = false;
	}

	public void ShowCanvas()
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.blocksRaycasts = true;
		_canvasGroup.interactable = true;
	}
	
}
