using System;
using UnityEngine;

[Serializable]
public struct Character
{
	public string Name;
	public Sprite Sprite;
}

[CreateAssetMenu(menuName = "Character Set")]
public class CharacterSet : ScriptableObject
{
	[SerializeField] private Character[] _characters;
	[SerializeField] private Character unknown;


	public Character GetCharacter(string character_name)
	{
		foreach (Character c in _characters)
			if (c.Name.Equals(character_name,StringComparison.OrdinalIgnoreCase))
				return c;

		return unknown;
	}
	
}
