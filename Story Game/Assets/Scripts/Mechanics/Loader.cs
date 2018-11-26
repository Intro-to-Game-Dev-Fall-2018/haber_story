using UnityEngine;

public class Loader : MonoBehaviour
{
	public static Loader i;
	public TextAsset inkJSONAsset;
	public CharacterSet Characters;
	public CharacterSet Backgrounds;
	public Settings Settings;
	
	private void Awake ()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
	}

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}
