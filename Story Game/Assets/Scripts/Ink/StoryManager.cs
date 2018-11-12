using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    private Story _story;
    [SerializeField] private StoryDisplay _display;

    private void Start()
    {
        _story = new Story(Loader.i.inkJSONAsset.text);
    }

    void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (_story.canContinue)
        {
            // Continue gets the next line of the story
            string text = _story.Continue();

            // This removes any white space from the text.
            text = text.Trim();

            // Display the text on screen!
            //CreateContentView(text);
        }
    }

    public string NextStoryElement()
    {
        if (_story.canContinue)
            return _story.Continue();
        return _story.currentChoices.ToString();
    }

    private void Update()
    {
    }

    private void RemoveChildren()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}