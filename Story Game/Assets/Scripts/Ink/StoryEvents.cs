using System;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class TextBlock
{
    public readonly bool IsDialogue;
    public readonly string Name;
    public readonly string Text;

    public TextBlock(string text)
    {
        if (text.Contains(":"))
        {
            int i = text.IndexOf(':');
            Name = text.Substring(0, i);
            Text = text.Substring(i + 1).Trim();
            IsDialogue = true;
        }
        else
        {
            Text = text;
            IsDialogue = false;
        }
    }
}

[Serializable]
public class BlockUpdateEvent : UnityEvent<TextBlock>
{
}

[Serializable]
public class TagUpdateEvent : UnityEvent<List<string>>
{
}

[Serializable]
public class ChoiceMade : UnityEvent<Choice>
{
}

[Serializable]
public class ChoiceUpdateEvent : UnityEvent<List<Choice>>
{
}

public class StoryEvents : MonoBehaviour
{

    public static StoryEvents i;

    public BlockUpdateEvent onBlockUpdate {get; private set;}
    public ChoiceMade onChoiceMade {get; private set;}
    public TagUpdateEvent onTagUpdate {get; private set;}
    public ChoiceUpdateEvent onChoiceUpdate { get; private set; }

    public bool Transition { get; private set; }

    private void Awake()
    {
        onBlockUpdate = new BlockUpdateEvent();
        onChoiceMade = new ChoiceMade();
        onTagUpdate = new TagUpdateEvent();
        onChoiceUpdate = new ChoiceUpdateEvent();

        if (i == null) i = this;
        else print("MULTIPLE STORY EVENT SYSTEMS IN USE");
    }

    public void InvokeTagUpdate(List<string> list)
    {
        Transition = false;
        foreach (string s in list)
            if (s.StartsWith("bg:"))
                Transition = true;

        onTagUpdate.Invoke(list);
    }
}