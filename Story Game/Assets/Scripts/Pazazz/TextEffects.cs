using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextEffects : MonoBehaviour
{
	private TextMeshProUGUI tmp;
	
	private void Start ()
	{
		tmp = GetComponent<TextMeshProUGUI>();
	}

	private IEnumerator Breathe()
	{
		while (true)
		{
			yield return new WaitForSeconds(.1f);
		}
	}
	
}
