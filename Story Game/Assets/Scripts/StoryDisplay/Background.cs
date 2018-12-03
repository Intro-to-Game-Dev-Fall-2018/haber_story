using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image _uiCover;
    [SerializeField] private Image _background;

    private CharacterSet _bgSet;
    private int numIter;

    private void Start()
    {
//        StoryEvents.i.onBlockUpdate.AddListener(CheckUpdate);
        StoryEvents.i.onTagUpdate.AddListener(CheckUpdate);
        _bgSet = Loader.i.Backgrounds;
        _uiCover.enabled = true;
    }

    private void CheckUpdate(TextBlock block)
    {
        if (!block.IsInstruction) return;

        switch (block.Name)
        {
            case "bg":
                ChangeBackground(block.Text);
                break;
            default:
                print(block.Name);
                break;
        }
    }

    private void CheckUpdate(List<string> list)
    {
        foreach (string s in list)
        {
            if (s.StartsWith("bg"))
                ChangeBackground(s.Substring(3).Trim());
        }
    }

    private void ChangeBackground(string bg)
    {
        StartCoroutine(BackgroundEffect(bg));
    }

    private IEnumerator BackgroundEffect(string bg)
    {
        Color imageColor = _uiCover.color;
        
        float alpha = numIter++ > 0 ? 0 : 1;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Loader.i.Settings.FadeBlackTime)
        {
            alpha = Mathf.Lerp(alpha, 1, t);
            imageColor.a = alpha;
            _uiCover.color = imageColor;
            yield return null;
            if (alpha > 1 - float.Epsilon) yield break;
        }

        _background.sprite = _bgSet.GetCharacter(bg).Sprite;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Loader.i.Settings.FadeInTime)
        {
            alpha = Mathf.Lerp(alpha, 0, t);
            imageColor.a = alpha;
            _uiCover.color = imageColor;
            yield return null;
            if (alpha < float.Epsilon) yield break;
        }
    }
}