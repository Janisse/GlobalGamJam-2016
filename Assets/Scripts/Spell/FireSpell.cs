using UnityEngine;
using System.Collections;

public class FireSpell : Spell
{

	void Start ()
	{
		type = ESpells.Fire;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		Debug.Log("Launch Fire Spell");
	}
}
