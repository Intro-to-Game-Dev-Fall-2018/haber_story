using UnityEngine;

public class KeyboardStoryController : MonoBehaviour
{

	private float lastMove;
	
	private void Update()
	{
		if (Input.GetButtonDown("Next") && Time.time > lastMove + Loader.i.Settings.DelayInput)
		{
			lastMove = Time.time;
			StoryManager.i.Next();
		}
	}
}
