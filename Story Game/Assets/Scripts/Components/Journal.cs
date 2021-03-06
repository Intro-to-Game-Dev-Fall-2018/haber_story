﻿using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Journal : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private Button _openJournal;
	[SerializeField] private Button _closeJournal;
	[SerializeField] private CanvasGroup _canvasGroup;
	[SerializeField] private Transform _content;
	[SerializeField] private ScrollRect _scrollRect;
	
	[Header("Prefabs")]
	[SerializeField] private TextMeshProUGUI _textPrefab;
	
	private List<string> _entries;
	
	private void Start () {
		_entries = new List<string>();
		StoryEvents.i.onBlockUpdate.AddListener(AddText);
		StoryEvents.i.onChoiceMade.AddListener(AddChoice);
		
		_openJournal.onClick.AddListener(OpenJournal);
		_closeJournal.onClick.AddListener(CloseJournal);
		MyUtilities.HideCanvasGroup(_canvasGroup);
	}

	private void AddText(TextBlock block)
	{
		if (block.IsDialogue)
			_entries.Add(block.Name+": "+block.Text);
		else
			_entries.Add(block.Text);
	}

	private void AddChoice(Choice choice)
	{
		_entries.Add(choice.text);
	}

	private void OpenJournal()
	{
		foreach (string s in _entries)
		{
			TextMeshProUGUI tmp = Instantiate(_textPrefab, _content);
			tmp.text = s;
		}

		StartCoroutine(NormToBottom());
		MyUtilities.ShowCanvasGroup(_canvasGroup);
	}

	private void CloseJournal()
	{
		foreach (Transform child in _content)
			Destroy(child.gameObject);	
		
		MyUtilities.HideCanvasGroup(_canvasGroup);
	}
	
	private IEnumerator NormToBottom()
	{
		yield return new WaitForEndOfFrame();
		_scrollRect.verticalNormalizedPosition = 0;

	}
}
