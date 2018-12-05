using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class Journal : MonoBehaviour
{
	
	private Stack<string> _entries;
	
	private void Start () {
		_entries = new Stack<string>();
		StoryEvents.i.onBlockUpdate.AddListener(AddText);
		StoryEvents.i.onChoiceMade.AddListener(AddChoice);
	}

	private void AddText(TextBlock block)
	{
		_entries.Push(block.Name+": "+block.Text);
	}

	private void AddChoice(Choice choice)
	{
		_entries.Push(choice.text);
	}
	
}
