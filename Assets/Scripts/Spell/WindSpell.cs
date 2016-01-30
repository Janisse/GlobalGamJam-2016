using UnityEngine;
using System.Collections;

public class WindSpell : Spell
{
	float duration = 2f;
	void Start ()
	{
		type = ESpells.Wind;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		Debug.Log("Launch Wind Spell");
		GameMode.instance.player.StatusManager.AddStatus(EStatus.Wind,duration);
	}
}