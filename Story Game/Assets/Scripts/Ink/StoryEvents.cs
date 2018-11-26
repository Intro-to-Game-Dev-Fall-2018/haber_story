using System;
using UnityEngine;
using UnityEngine.Events;

public class TextBlock
{
	public readonly bool IsDialogue;
	public readonly string Name;
	public readonly string Text;

	public TextBlock(string text)
	{
		if (text.Contains(":"))
		{
			int i = text.IndexOf(':');
			Name = text.Substring(0, i);
			Text = text.Substring(i + 1, text.Length - i - 1).Trim();
			IsDialogue = true;
		}
		else
		{
			Text = text;
			IsDialogue = false;
		}
	}
}

[Serializable]
public class StringUnityEvent : UnityEvent<string> {}

[Serializable]
public class BlockUpdateEvent : UnityEvent<TextBlock> {}

public class StoryEvents : MonoBehaviour
{

	public static StoryEvents i;
	
	public BlockUpdateEvent onBlockUpdate;
	public UnityEvent onChoiceMade;
	public StringUnityEvent onSceneChange;

	private void Awake()
	{
		onBlockUpdate = new BlockUpdateEvent();
		onChoiceMade = new UnityEvent();
		onSceneChange = new StringUnityEvent();
		if (i == null) i = this;
		else
		{
			print("MULTIPLE STORY EVENT SYSTEMS IN USE");
		}
	}
	
}
