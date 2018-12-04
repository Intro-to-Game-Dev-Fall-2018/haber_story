using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class ChoiceMade : UnityEvent<Choice> {}

public class StoryDisplay : MonoBehaviour
{

	[SerializeField] private Canvas UI;
	[SerializeField] private TextMeshProUGUI _textPrefab;
	[SerializeField] private Button _buttonPrefab;
	

	private void Start()
	{
		StoryEvents.i.onBlockUpdate.AddListener(Display);
	}

	public void Display(TextBlock block)
	{
		RemoveChildren();
		TextMeshProUGUI tmp = Instantiate(_textPrefab, UI.transform);
		tmp.text = block.Text;
		StartCoroutine(Typewriter(tmp));
	}

	public void DisplayOptions(List<Choice> choices)
	{
		int i = 0;

//		UI.GetComponentInChildren<TMP_Text>().text += "\n";
		
		foreach (Choice choice in choices)
		{
			Button button = CreateChoiceView (choice.text.Trim ());
			button.onClick.AddListener(() => {StoryEvents.i.onChoiceMade.Invoke(choice);});
			if (i == 0) EventSystem.current.SetSelectedGameObject(button.gameObject);
			i++;
		}
	}

	private Button CreateChoiceView (string text) {
		Button choice = Instantiate (_buttonPrefab,UI.transform);
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;
		return choice;
	}
	
	private void RemoveChildren()
	{
		foreach (Transform child in UI.transform)
			Destroy(child.gameObject);
	}

	private static IEnumerator Typewriter(TMP_Text tmp)
	{
		int chars = 0;
		while (chars < tmp.text.Length)
		{
			tmp.maxVisibleCharacters = chars++;
			yield return new WaitForSeconds(.001f);
		}

		tmp.maxVisibleCharacters = tmp.text.Length;
	} 
}
