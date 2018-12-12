using System.Collections;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager i;

    public Story Story { get; private set; }

    private bool _waitingForChoice;
    private bool isFastForwarding;

    private void Awake()
    {
        if (i == null) i = this;
        Story = new Story(Loader.i.inkJSONAsset.text);
    }

    private void Start()
    {
        StoryEvents.i.onChoiceMade.AddListener(MakeChoice);
        StartCoroutine(DelayStart());
    }

    public void Next()
    {
        if (_waitingForChoice) return;
        
        if (Story.canContinue)
            NextText();
        else if (Story.currentChoices.Count > 0)
            NextOptions();
        else
            Story.ResetState();
    }
    
    private void NextText()
    {
        string text = Story.Continue();

        if (text.Trim().Length == 0)
        {
            Next();
            return;
        }
        
        AudioManager.i.Play("Dialogue");
        
        if (Story.currentTags.Count > 0)
            StoryEvents.i.InvokeTagUpdate(Story.currentTags);

        TextBlock block = new TextBlock(text);
            StoryEvents.i.onBlockUpdate.Invoke(block);
    }

    private void NextOptions()
    {
        _waitingForChoice = true;
        StoryEvents.i.onChoiceUpdate.Invoke(Story.currentChoices);
    }
    
    public void MakeChoice(int choice)
    {
        Story.ChooseChoiceIndex(choice);
        _waitingForChoice = false;
        Next();
    }
    
    private void MakeChoice(Choice choice)
    {
        Story.ChooseChoiceIndex(choice.index);
        _waitingForChoice = false;
        Next();
    }

    private IEnumerator DelayStart()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Next();
    }

}