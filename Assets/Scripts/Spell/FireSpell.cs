using UnityEngine;
using System.Collections;

public class FireSpell : Spell {

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);

		Debug.Log("Launch Fire Spell");
	}
}
