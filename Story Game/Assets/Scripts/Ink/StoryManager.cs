using System.Collections;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager i;

    private Story _story;
    [SerializeField] private StoryDisplay _storyDisplay;

    private bool _waitingForChoice;
    
    private float lastMove;

    private void Start()
    {
        if (i == null) i = this;
        _story = new Story(Loader.i.inkJSONAsset.text);
        _storyDisplay.ButtonClicked.AddListener(MakeChoice);
        Next();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > .1 && Time.time > lastMove + Loader.i.Settings.DelayInput)
            Next();
    }

    public void TalkNPC(string name)
    {
        _story.ChoosePathString(name);
        Next();
    }

    private void MakeChoice(Choice choice)
    {
        _waitingForChoice = false;
        _story.ChooseChoiceIndex(choice.index);
        StoryEvents.i.onChoiceMade.Invoke();
        Next();
    }

    private void Next()
    {
        lastMove = Time.time;
        
        if (_waitingForChoice) return;
        
        if (_story.canContinue)
            NextText();
        else if (_story.currentChoices.Count > 0)
            NextOptions();
        else
            _story.ResetState();
    }

    private void NextText()
    {
        string text = _story.Continue();

        if (text.Trim().Length == 0)
        {
            Next();
            return;
        }
        
        TextBlock block = new TextBlock(text);
        StoryEvents.i.onBlockUpdate.Invoke(block);
        
        if (_story.currentTags.Count > 0)
            StoryEvents.i.onTagUpdate.Invoke(_story.currentTags);
    }

    private void NextOptions()
    {
        _waitingForChoice = true;
        _storyDisplay.DisplayOptions(_story.currentChoices);
    }

    private IEnumerator DelayNextCall()
    {
        _waitingForChoice = true;
        yield return new WaitForSeconds(Loader.i.Settings.FadeBlackTime);
        _waitingForChoice = false;
        Next();
    }
}