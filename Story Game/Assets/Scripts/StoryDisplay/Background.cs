using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] private Image _uiCover;
    [SerializeField] private Image _background;

    private void Start()
    {
        StoryEvents.i.onTagUpdate.AddListener(CheckUpdate);
        _uiCover.enabled = true;
    }

    private void CheckUpdate(List<string> list)
    {
        if (!StoryEvents.i.Transition) return;
        
        foreach (string s in list)
            if (s.StartsWith("bg:"))
                Transition(s.Substring(3).Trim());
    }

    private void Transition(string bg)
    {
        AudioManager.i.Play("Transition");
        _uiCover.DOFade(1, Loader.i.Settings.FadeBlackTime).SetEase(Ease.Linear)
            .OnComplete(()=>
            {
                _background.sprite = Loader.i.Backgrounds.GetCharacter(bg).Sprite;
                _background.SetNativeSize();
                _uiCover.DOFade(0, Loader.i.Settings.FadeInTime).SetEase(Ease.Linear);
            });
    }
}