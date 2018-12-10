using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	[Header("Components")]
	[SerializeField] private Button _openMenu;
	[SerializeField] private Button _closeMenu;
	[SerializeField] private Button _exitGame;
	[SerializeField] private CanvasGroup _canvasGroup;
	
	private void Start () {
		_openMenu.onClick.AddListener(ShowCanvas);
		_closeMenu.onClick.AddListener(HideCanvas);
		_exitGame.onClick.AddListener(()=>{Loader.i.LoadMenu();});
		HideCanvas();
	}

	private void HideCanvas()
	{
		_canvasGroup.alpha = 0f;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.interactable = false;
	}

	private void ShowCanvas()
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.blocksRaycasts = true;
		_canvasGroup.interactable = true;
	}
}
