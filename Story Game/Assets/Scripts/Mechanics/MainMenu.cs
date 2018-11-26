using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	private bool isLoading;
	
	public void StartGame()
	{
		StartCoroutine(Load("Game"));
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	private IEnumerator Load(string name)
	{
		if (isLoading) yield break;

		Scene currentScene = SceneManager.GetActiveScene();
		isLoading = true;
		AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}

		operation = SceneManager.UnloadSceneAsync(currentScene);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
		
		isLoading = false;
	}
	
}
