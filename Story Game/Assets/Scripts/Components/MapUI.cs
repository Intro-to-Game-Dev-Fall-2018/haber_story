using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{

	[SerializeField] private Button _downtown;
	[SerializeField] private Button _ferrySt;
	
	private void Start () {
		_downtown.onClick.AddListener(() =>
		{
			StoryManager.i.MakeChoice(0);
		});
		_ferrySt.onClick.AddListener(() =>
		{
			StoryManager.i.MakeChoice(1);
		});
	}
}
