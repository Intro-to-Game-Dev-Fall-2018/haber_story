using System.Collections;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager i;

    private Story _story;
    [SerializeField] private StoryDisplay _storyDisplay;

    private bool _waitingForChoice;
    private bool isFastForwarding;

    private void Start()
    {
        if (i == null) i = this;
        _story = new Story(Loader.i.inkJSONAsset.text);
        StoryEvents.i.onChoiceMade.AddListener(MakeChoice);
        StartCoroutine(DelayStart());
    }

    public void Next()
    {
        if (_waitingForChoice) return;
        
        if (_story.canContinue)
            NextText();
        else if (_story.currentChoices.Count > 0)
            NextOptions();
        else
            _story.ResetState();
    }
    
    public void FastForward()
    {
        if (!_story.canContinue) return;
        if (isFastForwarding) return;
        StartCoroutine(FF());
    }

    public void StopFastForward()
    {
        isFastForwarding = false;
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
            StoryEvents.i.InvokeTagUpdate(_story.currentTags);

        TextBlock block = new TextBlock(text);
            StoryEvents.i.onBlockUpdate.Invoke(block);
    }

    private void NextOptions()
    {
        _waitingForChoice = true;
        _storyDisplay.DisplayOptions(_story.currentChoices);
    }
    
    private void MakeChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _waitingForChoice = false;
        Next();
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Next();
    }

    private IEnumerator FF()
    {
        isFastForwarding = true;
        while (_story.canContinue)
        {
            if (!isFastForwarding) yield break;
            Next();
            yield return new WaitForSeconds(Loader.i.Settings.TimePerLetter * _story.currentText.Length);
        }
        
        if (isFastForwarding) Next();
        isFastForwarding = false;
    }

}