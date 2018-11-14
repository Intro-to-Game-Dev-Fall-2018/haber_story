using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private Story _story;
    [SerializeField] private StoryDisplay _display;
//    [SerializeField] private Background _background;

    private float lastMove;

    private void Start()
    {
        _story = new Story(Loader.i.inkJSONAsset.text);
        _display.Display(_story.currentText);
        _display.ButtonClicked.AddListener(MakeChoice);
    }
    
    private void Update()
    {
        if (Input.GetButton("Submit") && Time.time > lastMove+.8)
        {
            NextStory();
            lastMove = Time.time;
        }
    }

    private void MakeChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _display.Display(_story.Continue());
        print(choice.sourcePath);
    }

    private void NextStory()
    {
        if  (_story.canContinue)
            _display.Display(_story.Continue());
        else
            _display.DisplayOptions(_story.currentChoices);
    }

}