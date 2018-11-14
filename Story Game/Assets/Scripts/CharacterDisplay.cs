using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _renderer;
    
    private CharacterSet _characters;

    private void Start()
    {
        _characters = Loader.i.Characters;
    }
    
    public void Display(string name)
    {
        _renderer.sprite = _characters.GetCharacter(name).Sprite;
    }
    
}
