using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardStoryController : MonoBehaviour
{

	private float lastMove;
	
	private void Update()
	{
		if (Input.GetAxis("Horizontal") > .1 && Time.time > lastMove + Loader.i.Settings.DelayInput)
		{
			lastMove = Time.time;
			StoryManager.i.Next();
		}
	}
}
