using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class ChoiceMade : UnityEvent<Choice> {}

public class StoryDisplay : MonoBehaviour
{

	[SerializeField] private Canvas UI;
	[SerializeField] private TextMeshProUGUI _textPrefab;
	[SerializeField] private Button _buttonPrefab;

	public ChoiceMade ButtonClicked;

	private void Awake()
	{
		if (ButtonClicked == null) ButtonClicked = new ChoiceMade();
	}

	public void Display(string text)
	{
		RemoveChildren();
		TextMeshProUGUI tmp = Instantiate(_textPrefab, UI.transform);
		tmp.text = text;
	}

	public void DisplayOptions(List<Choice> choices)
	{
		RemoveChildren();
		foreach (Choice choice in choices)
		{
			Button button = CreateChoiceView (choice.text.Trim ());
			
			button.onClick.AddListener(() =>
			{
				ButtonClicked.Invoke(choice);
			});
		}
		
	}

	private Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (_buttonPrefab,UI.transform);
		
		// Gets the text from the button prefab
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;

		// Make the button expand to fit the text
//		HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
//		layoutGroup.childForceExpandHeight = false;

		return choice;
	}
	
	
	private void RemoveChildren()
	{
		foreach (Transform child in UI.transform)
			Destroy(child.gameObject);
	}
}
