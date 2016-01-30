using UnityEngine;
using System.Collections;

public class WindSpell : Spell
{
	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		Debug.Log("Launch Wind Spell");
	}
}