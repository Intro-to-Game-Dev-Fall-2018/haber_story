using UnityEngine;
using UnityEngine.UI;

public class ButtonComponentAdder : MonoBehaviour {

	private void Awake () {
		foreach (Button b in FindObjectsOfType<Button>()) 
		{
			if (b.GetComponent<ButtonAudio>() != null) continue;
			b.gameObject.AddComponent(typeof(ButtonAudio));
		}
	}
}
