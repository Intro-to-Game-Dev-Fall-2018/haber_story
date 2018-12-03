using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{

	[SerializeField] private GameObject _left;
	[SerializeField] private GameObject _right;

	[SerializeField] private GameObject _characterPrefab;


	private void Start () {
		StoryEvents.i.onTagUpdate.AddListener(FillCharacters);
	}

	private void FillCharacters(List<string> characters)
	{
		var activeCharacters = new List<string>();

		foreach (string s in characters)
		{
			if (!s.StartsWith("ch")) continue;
			string character_name = s.Substring(3).Trim();
			
			if (activeCharacters.Count == 0) Clear();
			
			if (activeCharacters.Contains(character_name)) continue;
			activeCharacters.Add(character_name);
			
			Character character_var = Loader.i.Characters.GetCharacter(character_name);


			bool left = character_var.PreferLeft;
			
			GameObject i = Instantiate(_characterPrefab, left ? _left.transform : _right.transform);
			i.GetComponent<Image>().sprite = character_var.Sprite;
			
			print(character_var.Name);
		}
	}

	private void Clear()
	{
		foreach (Transform child in _left.transform)
			Destroy(child.gameObject);
		foreach (Transform child in _right.transform)
			Destroy(child.gameObject);
	}
	
}
