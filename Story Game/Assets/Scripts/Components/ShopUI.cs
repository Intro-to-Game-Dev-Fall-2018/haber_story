using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _money;
	[SerializeField] private Button _buttonPrefab;
	[SerializeField] private Transform UI;
	
	private void Start ()
	{
		StoryManager.i.Story.ObserveVariable("money",
			( varName, newValue) => { ObserveMoney((int) newValue); });
		
		StoryEvents.i.onChoiceUpdate.AddListener(DisplayOptions);
	}
	
	private void ObserveMoney(int newValue)
	{
		_money.text = newValue+" c";
	}
	
	public void DisplayOptions(List<Choice> choices)
	{
		foreach (Transform child in UI)
			Destroy(child.gameObject);
		
		foreach (Choice choice in choices)
		{
			Button button = CreateChoiceView (choice.text.Trim ());
			button.onClick.AddListener(() => {StoryEvents.i.onChoiceMade.Invoke(choice);});
		}
	}

	private Button CreateChoiceView (string text) {
		Button choice = Instantiate (_buttonPrefab,UI);
		Text choiceText = choice.GetComponentInChildren<Text>();
		choiceText.text = text;
		return choice;
	}
	
}
