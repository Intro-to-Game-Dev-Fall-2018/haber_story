using UnityEngine;
using UnityEngine.UI;

public class NavMenu : MonoBehaviour
{
	[Header("Buttons")]
	[SerializeField] private Button _next;
	[SerializeField] private Button _fastForward;
	[SerializeField] private Button _pause;
	
	private void Start () {
		_next.onClick.AddListener(() => { StoryManager.i.Next();});
		_fastForward.onClick.AddListener(()=>{StoryManager.i.FastForward();});
		_pause.onClick.AddListener(()=>{StoryManager.i.StopFastForward();});
	}

}
