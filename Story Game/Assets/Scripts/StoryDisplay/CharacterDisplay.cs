using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{

	private Character _identity;
	private Image _img;


	private void OnEnable()
	{
		_img = GetComponent<Image>();
		StoryEvents.i.onBlockUpdate.AddListener(BlockUpdate);
	}

	public void Init(Character character)
	{
		_identity = character;
		_img.sprite = character.Sprite;
	}

	public void Flip()
	{
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}

	private void BlockUpdate(TextBlock block)
	{
		if (!block.IsDialogue) return;
		if (block.Name != _identity.Name) return;

		transform.DOShakePosition(3f, 30f,5,120f).SetDelay(.1f);
	}

	private void TagUpdate(List<string> list)
	{
		foreach (string s in list)
		{
			if (!s.StartsWith("cp:")) continue;
				if (s.Substring(3).Trim() == _identity.Name)
					transform.DOShakePosition(1.8f,75f);
		}	
	}
	
	private void OnDestroy()
	{
//		StoryEvents.i.onTagUpdate.RemoveListener(TagUpdate);
		StoryEvents.i.onBlockUpdate.RemoveListener(BlockUpdate);
	}
}
