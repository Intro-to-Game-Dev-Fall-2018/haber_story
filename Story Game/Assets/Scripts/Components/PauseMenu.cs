using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	[Header("Components")]
	[SerializeField] private Button _openMenu;
	[SerializeField] private Button _closeMenu;
	[SerializeField] private Button _exitGame;
	[SerializeField] private CanvasGroup _canvasGroup;
	
	private void Start () {
		_openMenu.onClick.AddListener(()=>
		{
			MyUtilities.ShowCanvasGroup(_canvasGroup);
		});
		_closeMenu.onClick.AddListener(()=>
		{
			MyUtilities.HideCanvasGroup(_canvasGroup);
		});
		_exitGame.onClick.AddListener(() =>
		{
			Loader.i.LoadMenu();
		});
		
		MyUtilities.HideCanvasGroup(_canvasGroup);
	}
}
