using UnityEngine;
using System.Collections;

public class WindSpell : Spell
{
	void Start ()
	{
		type = ESpells.Wind;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		Debug.Log("Launch Wind Spell");
	}
}