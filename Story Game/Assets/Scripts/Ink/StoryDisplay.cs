using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryDisplay : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _storyView;
	[SerializeField] private GameObject _buttonPrefab;

	public void Display(string text)
	{
		_storyView.text = text;
	}
}
