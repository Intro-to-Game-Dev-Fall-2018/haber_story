using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, Interactable
{

	[SerializeField] private string _inkTarget;

	public void Interact()
	{
		StoryManager.i.TalkNPC(_inkTarget);
	}
}
