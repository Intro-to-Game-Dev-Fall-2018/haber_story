﻿using System;
using Boo.Lang;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager i;

    private Story _story;
    [SerializeField] private StoryDisplay _storyDisplay;
    [SerializeField] private CharacterDisplay _characterDisplay;
    [SerializeField] private DialogueGUI _dialogueGui;

    private bool _waitingForChoice;
    
//    [SerializeField] private Background _background;

    private float lastMove;

    private void Start()
    {
        if (i == null) i = this;
        _story = new Story(Loader.i.inkJSONAsset.text);
        _storyDisplay.Display(_story.currentText);
        _storyDisplay.ButtonClicked.AddListener(MakeChoice);
        Next();
    }

    private void Update()
    {
        if (Input.GetButton("Submit") && Time.time > lastMove + .8)
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
        string name;

        if (text.Trim().Length == 0)
        {
            Next();
            return;
        }
        
        if (text.Contains(":"))
        {
            int i = text.IndexOf(':');
            name = text.Substring(0, i);
            text = text.Substring(i + 1, text.Length - i - 1).Trim();
            _dialogueGui.DisplayCharacter(name);
        }
        else
            _dialogueGui.NoCharacter();


        _storyDisplay.Display(text);
    }

    private void NextOptions()
    {
        _waitingForChoice = true;
        _storyDisplay.DisplayOptions(_story.currentChoices);
    }
}