using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class StoryDisplay : MonoBehaviour
{

	[SerializeField] private Canvas UI;
	[SerializeField] private TextMeshProUGUI _textPrefab;
	[SerializeField] private Button _buttonPrefab;

	private bool _transition;
	
	private void Start()
	{
		StoryEvents.i.onBlockUpdate.AddListener(Display);
		StoryEvents.i.onTagUpdate.AddListener(Tag);
	}

	private void Tag(List<string> list)
	{
		if (StoryEvents.i.Transition)
			_transition = true;
	}

	public void Display(TextBlock block)
	{
		float delay = _transition ? Loader.i.Settings.FadeBlackTime : 0;
		_transition = false;

		StartCoroutine(Typewriter(block,delay));
	}

	public void DisplayOptions(List<Choice> choices)
	{
		RemoveChildren();
		
		int i = 0;

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

	private IEnumerator Typewriter(TextBlock block,float delay)
	{
		yield return new WaitForSeconds(delay);
		RemoveChildren();
		TextMeshProUGUI tmp = Instantiate(_textPrefab, UI.transform);
		tmp.text = block.Text;
		
		int chars = 0;
		tmp.alignment = TextAlignmentOptions.Top;
			
		while (chars < tmp.textInfo.characterCount)
		{
			tmp.maxVisibleCharacters = chars++;
			yield return new WaitForSeconds(Loader.i.Settings.TimePerLetter);
		}

		tmp.maxVisibleCharacters = tmp.text.Length;
		StoryEvents.i.onTypeComplete.Invoke();
	} 
}
