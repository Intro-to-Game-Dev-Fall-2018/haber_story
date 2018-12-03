using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharNamePanel : MonoBehaviour
{
	private Image _img;
	private TextMeshProUGUI _tmp;
 	
	private void Start ()
	{
		_img = GetComponent<Image>();
		_tmp = GetComponentInChildren<TextMeshProUGUI>();
		StoryEvents.i.onBlockUpdate.AddListener(OnUpdate);
	}

	private void OnUpdate(TextBlock block)
	{
		if (!block.IsDialogue)
		{
			_img.enabled = false;
			_tmp.enabled = false;
			return;
		}

		_tmp.enabled = true;
		_img.enabled = true;
		_tmp.text = block.Name;
	}

}
