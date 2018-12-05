using UnityEngine;
using UnityEngine.UI;

public class NavMenu : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] private Button _next;
	[SerializeField] private Button _fastForward;
	
	private void Start () {
		_next.onClick.AddListener(Next);
		_fastForward.onClick.AddListener(FastForward);
	}

	private void Next()
	{
		StoryManager.i.Next();
	}

	private void FastForward()
	{
		
	}
	
}
