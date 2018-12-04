using System.Collections;
using System.Collections.Generic;
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
        StoryEvents.i.onChoiceMade.AddListener(MakeChoice);
        StartCoroutine(DelayStart());
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > .1 && Time.time > lastMove + Loader.i.Settings.DelayInput)
            Next();
    }

    private void MakeChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _waitingForChoice = false;
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
        
        if (_story.currentTags.Count > 0)
            StoryEvents.i.onTagUpdate.Invoke(_story.currentTags);

        TextBlock block = new TextBlock(text);
            StoryEvents.i.onBlockUpdate.Invoke(block);
        
    }

    private void NextOptions()
    {
        _waitingForChoice = true;
        _storyDisplay.DisplayOptions(_story.currentChoices);
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForEndOfFrame();
        Next();
    }

}