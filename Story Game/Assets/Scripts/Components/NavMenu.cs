using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NavMenu : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] private Button _next;
	[SerializeField] private Button _fastForward;
	[SerializeField] private Button _pause;

	private float lastMove;
	private bool isFastForwarding;
	
	private void Start () {
		_next.onClick.AddListener(Next);
		_fastForward.onClick.AddListener(()=>
		{
			if (!isFastForwarding) StartCoroutine(FF());
		});
		_pause.onClick.AddListener(() =>
		{
			isFastForwarding = false;
		});
	}

	private void Next()
	{
		if (!(Time.time > lastMove + Loader.i.Settings.DelayInput)) return;
		
		lastMove = Time.time;
		StoryManager.i.Next();
	}
	
	private IEnumerator FF()
	{
		isFastForwarding = true;
		while (StoryManager.i.Story.canContinue)
		{
			if (!isFastForwarding) yield break;
			Next();
			yield return new WaitForSeconds(Loader.i.Settings.TimePerLetter * StoryManager.i.Story.currentText.Length);
		}
        
		if (isFastForwarding) Next();
		isFastForwarding = false;
	}

}
