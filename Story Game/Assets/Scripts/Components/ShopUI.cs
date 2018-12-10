using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _money;
	
	private void Start ()
	{
		StoryManager.i.Story.ObserveVariable("money",
			( varName, newValue) => { ObserveMoney((string) newValue); });
	}

	private void ObserveMoney(string newValue)
	{
		_money.text = newValue;
	}
	
}
