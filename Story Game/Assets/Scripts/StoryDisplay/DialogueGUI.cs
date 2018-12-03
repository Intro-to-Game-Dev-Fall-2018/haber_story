using UnityEngine;
using UnityEngine.UI;

public class DialogueGUI : MonoBehaviour
{

	[SerializeField] private Image _characterDisplay;
	[SerializeField] private LayoutElement _characterWindow;
	[SerializeField] private CanvasGroup _characterCanvasGroup;
	
	private CharacterSet _characters;

	private void Start()
	{
		_characters = Loader.i.Characters;
		StoryEvents.i.onBlockUpdate.AddListener(Display);
	}

	private void Display(TextBlock block)
	{
		if (block.IsDialogue)
			DisplayDialogue(block);
		else
			DisplayText();
	}
	
	private void DisplayDialogue(TextBlock block)
	{
		_characterDisplay.sprite = _characters.GetCharacter(block.Name).Sprite;
		_characterWindow.ignoreLayout = false;
		ShowCanvas();
		ShowCanvas(_characterCanvasGroup);
	}
	
	private void DisplayText()
	{
		_characterDisplay.sprite = null;
		_characterWindow.ignoreLayout = true;
		HideCanvas(_characterCanvasGroup);
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

	public void HideCanvas()
	{
		HideCanvas(GetComponent<CanvasGroup>());
	}

	public void ShowCanvas()
	{
		ShowCanvas(GetComponent<CanvasGroup>());
	}
	
}
