using Ink.Runtime;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public static Loader i;
	public TextAsset inkJSONAsset;
	public CharacterSet Characters;
	
	private void Awake ()
	{
		if (i == null) i = this;
		else Destroy(gameObject);
	}

}
