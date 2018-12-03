using UnityEngine;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{
		Loader.i.LoadGame();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

}
