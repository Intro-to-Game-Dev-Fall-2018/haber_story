using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueGUI : MonoBehaviour
{

	[SerializeField] private Image _characterDisplay;
	[SerializeField] private LayoutElement _characterWindow;
	[SerializeField] private CanvasGroup _characterCanvasGroup;

	[SerializeField] private TextMeshProUGUI _characterName;
	[SerializeField] private TextMeshProUGUI _dialogueDisplay;
	
	private CharacterSet _characters;

	private void Start()
	{
		_characters = Loader.i.Characters;
	}

	public void DisplayCharacter(string name)
	{
		_characterDisplay.sprite = _characters.GetCharacter(name).Sprite;
		_characterName.text = name;
		_characterWindow.ignoreLayout = false;
		ShowCanvas();
		ShowCanvas(_characterCanvasGroup);
	}
	
	public void NoCharacter()
	{
		_characterDisplay.sprite = null;
		_characterName.text = "";
		_characterWindow.ignoreLayout = true;
		HideCanvas(_characterCanvasGroup);
	}
	
	private static void HideCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
		canvas.interactable = false;
	}

	private static void ShowCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
		canvas.interactable = true;
	}

	public void HideCanvas()
	{
		HideCanvas(GetComponent<CanvasGroup>());
//		_canvasGroup.alpha = 0f;
//		_canvasGroup.blocksRaycasts = false;
//		_canvasGroup.interactable = false;
	}

	public void ShowCanvas()
	{
		ShowCanvas(GetComponent<CanvasGroup>());
//		_canvasGroup.alpha = 1f;
//		_canvasGroup.blocksRaycasts = true;
//		_canvasGroup.interactable = true;
	}
	
}
