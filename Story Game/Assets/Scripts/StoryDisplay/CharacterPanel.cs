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
		StoryEvents.i.onTagUpdate.AddListener(FillCheck);
	}
	
	private void FillCheck(List<string> tags)
	{
		if (StoryEvents.i.Transition)
			StartCoroutine(DelayedFill(tags));
		else
			Fill(tags);
	}

	private void Fill(IEnumerable<string> tags)
	{
		var activeCharacters = new List<string>();
		
		foreach (string s in tags)
		{
			if (!s.StartsWith("ch")) continue;
			
			if (s[2]=='c')
			{
				Clear();
				return;
			}

			if (activeCharacters.Count == 0) Clear();
			else if (activeCharacters.Contains(s)) continue;
			
			activeCharacters.Add(s);
			Place(s);
		}
		
		RefreshDisplay();
	}

	private void Place(string line)
	{
		bool left = line[2] == 'l';
		
		Character character_var = Loader.i.Characters.GetCharacter(line.Substring(4).Trim());

		GameObject gameObj = Instantiate(_characterPrefab, left ? _left.transform : _right.transform);
		CharacterDisplay characterDisplay = gameObj.AddComponent(typeof(CharacterDisplay)) as CharacterDisplay;
			
		characterDisplay.Init(character_var);
		if (!left) characterDisplay.Flip();
	}
	
	private IEnumerator DelayedFill(IEnumerable<string> tags)
	{
		yield return new WaitForSeconds(Loader.i.Settings.FadeBlackTime);
		Fill(tags);
	}


	private void Clear()
	{
		foreach (Transform child in _left.transform)
			Destroy(child.gameObject);
		foreach (Transform child in _right.transform)
			Destroy(child.gameObject);
	}

	private void RefreshDisplay()
	{
		_left.GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
		_right.GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
	}
	
}
