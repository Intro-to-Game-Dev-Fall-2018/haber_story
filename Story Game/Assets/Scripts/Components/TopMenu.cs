using UnityEngine;
using UnityEngine.UI;

public class TopMenu : MonoBehaviour
{
	[SerializeField] private Button _menu;
	
	private void Start () {
		_menu.onClick.AddListener(Menu);
	}

	private void Menu()
	{
		Loader.i.LoadMenu();
	}
}
