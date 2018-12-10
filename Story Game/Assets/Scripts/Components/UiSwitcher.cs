using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSwitcher : MonoBehaviour
{

	[SerializeField] private CanvasGroup _normal;
	[SerializeField] private CanvasGroup _shop;
	[SerializeField] private CanvasGroup _map;

	private void Start () {
		StoryEvents.i.onTagUpdate.AddListener(OnTagUpdate);
		HideAll();
		ShowCanvas(_normal);
	}
	
	private void OnTagUpdate(List<string> tags)
	{
		if (StoryEvents.i.Transition)
			StartCoroutine(Delay(tags));
		else
			ShowUI(tags);
	}

	private void ShowUI(IEnumerable<string> tags)
	{
		foreach (string s in tags)
		{
			if (!s.StartsWith("ui:")) continue;
			
			HideAll();
			
			switch (s.Substring(3).Trim())
			{
					case "shop": 
						StoryManager.i.Next();
						ShowCanvas(_shop);
						break;
					case "map" :
						ShowCanvas(_map);
						break;
					default: 
						ShowCanvas(_normal);
						break;
			}
		}
	}
	
	private IEnumerator Delay(IEnumerable<string> tags)
	{
		yield return new WaitForSeconds(Loader.i.Settings.FadeBlackTime);
		ShowUI(tags);
	}

	private void HideAll()
	{
		HideCanvas(_normal);
		HideCanvas(_shop);
		HideCanvas(_map);
	}
	
		
	private static void HideCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 0f;
		canvas.blocksRaycasts = false;
		canvas.interactable = false;
	}

	private static void ShowCanvas(CanvasGroup canvas)
	{
		canvas.alpha = 1f;
		canvas.blocksRaycasts = true;
		canvas.interactable = true;
	}
	
}
