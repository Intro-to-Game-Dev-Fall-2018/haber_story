using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [Header("Mouse Events")]
    [SerializeField] private AudioClip _mouseOver;
    [SerializeField] private AudioClip _mouseExit;
    [SerializeField] private AudioClip _mouseClick;
    
    [Header("Interactions")]
    [SerializeField] private AudioClip _dialogue;
    [SerializeField] private AudioClip _transition;

    [Header("Components")]
    [SerializeField] private AudioSource _source;

    public static AudioManager i;

    private void Start()
    {
        if (i == null) i = this;
        else Destroy(gameObject);
    }

    public void Play(string sound)
    {
        switch (sound)
        {
            case "MouseOverButton":
                _source.PlayOneShot(_mouseOver);
                break;
            case "MouseClickButton":
                _source.PlayOneShot(_mouseClick);
                break;
            case "MouseExitButton":
                _source.PlayOneShot(_mouseExit);
                break;
            case "Dialogue":
                _source.PlayOneShot(_dialogue);
                break;
            case "Transition":
                _source.PlayOneShot(_transition);
                break;
        }
    }
}