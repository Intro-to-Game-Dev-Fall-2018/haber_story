using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	public static Loader i;
	public TextAsset inkJSONAsset;
	public CharacterSet Characters;
	public CharacterSet Backgrounds;
	public Settings Settings;
	
	private bool _isLoading;

	public bool load;
	
	private void Awake ()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
	}

	public void LoadGame()
	{
		StartCoroutine(Load("Game", "Menu"));
	}
	
	public void LoadMenu()
	{
		StartCoroutine(Load("Menu", "Game"));
	}

	private void Start()
	{
//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Locked;

		if (!load) return;
		
		StartCoroutine(Load("Menu"));
		StartCoroutine(Load("Music"));
	}
	
	private static IEnumerator Load(string name)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
	}
	
	
	private IEnumerator Load(string name,string unload)
	{
		if (_isLoading) yield break;

		_isLoading = true;
		AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}

		operation = SceneManager.UnloadSceneAsync(unload);
		while (!operation.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
		
		_isLoading = false;
	}
}
