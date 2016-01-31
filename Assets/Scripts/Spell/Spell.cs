using UnityEngine;
using System.Collections;

public enum ESpells
{
	NA,
	Wind,
	Fire,
	Nausea,
	BunnyHop
}

abstract public class Spell : MonoBehaviour
{
	public Sprite Icon = null;
	internal ESpells type = ESpells.NA;
	internal virtual void LaunchEffect (PlayerCharacter Player)
	{
		Debug.Log("Launch "+type.ToString()+" Spell");
	}
}