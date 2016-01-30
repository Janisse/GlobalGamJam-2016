using UnityEngine;
using System.Collections;

public enum Spells
{
	Wind,
	Fire
}

abstract public class Spell : MonoBehaviour
{
	public Sprite Icon = null;

	internal virtual void LaunchEffect (PlayerCharacter Player)
	{

	}
}