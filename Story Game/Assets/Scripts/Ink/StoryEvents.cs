using System;
using UnityEngine;
using UnityEngine.Events;

public class TextBlock
{
	public bool IsDialogue;
	public string Name;
	public string Text;

}

[Serializable]
public class BlockUpdateEvent : UnityEvent<TextBlock> {}

public class StoryEvents 
{

	public static BlockUpdateEvent onBlockUpdate;
	
	
	private void Awake()
	{
		onBlockUpdate = new BlockUpdateEvent();
		
	}
	
}
