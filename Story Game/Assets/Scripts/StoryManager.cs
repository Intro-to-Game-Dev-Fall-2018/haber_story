using System;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private Story _story;
    [SerializeField] private StoryDisplay _storyDisplay;
    [SerializeField] private CharacterDisplay _characterDisplay;
    
//    [SerializeField] private Background _background;

    private float lastMove;

    private void Start()
    {
        _story = new Story(Loader.i.inkJSONAsset.text);
        _storyDisplay.Display(_story.currentText);
        _storyDisplay.ButtonClicked.AddListener(MakeChoice);
    }
    
    private void Update()
    {
        if (Input.GetButton("Submit") && Time.time > lastMove+.8)
            Next();
    }

    private void MakeChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        Next();
    }

    private void Next()
    {
        lastMove = Time.time;
        
        if  (_story.canContinue)
            NextText();
        else if (_story.currentChoices.Count > 0)
            NextOptions();
        else
            _story.ResetState();
            
        
    }

    private void NextText()
    {
        string text = _story.Continue();
        string name;
        
        if (text.Contains(":"))
        {
            int i = text.IndexOf(':');
            name = text.Substring(0, i);
            text = text.Substring(i+1,text.Length-i-1).Trim();
            _characterDisplay.Display(name);
        }
        else
            _characterDisplay.NoDisplay();
        
        
        _storyDisplay.Display(text);
    }

    private void NextOptions()
    {
        _storyDisplay.DisplayOptions(_story.currentChoices);
    }

}