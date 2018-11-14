using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour {
    
    private CharacterSet _characters;

    private void Start()
    {
        _characters = Loader.i.Characters;
    }
    
    
}
