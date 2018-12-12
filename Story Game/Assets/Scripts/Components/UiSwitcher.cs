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
		MyUtilities.ShowCanvasGroup(_normal);
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
						MyUtilities.ShowCanvasGroup(_shop);
						break;
					case "map" :
						MyUtilities.ShowCanvasGroup(_map);
						break;
					default: 
						MyUtilities.ShowCanvasGroup(_normal);
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
		MyUtilities.HideCanvasGroup(_normal);
		MyUtilities.HideCanvasGroup(_shop);
		MyUtilities.HideCanvasGroup(_map);
	}
}
