using UnityEngine;

public class MyUtilities  {

	public static void HideCanvasGroup(CanvasGroup canvasGroup)
	{
		canvasGroup.alpha = 0f;
		canvasGroup.blocksRaycasts = false;
		canvasGroup.interactable = false;
	}

	public static void ShowCanvasGroup(CanvasGroup canvasGroup)
	{
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;
		canvasGroup.interactable = true;
	}
}
