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
		GameMode.instance.player.StatusManager.AddStatus(new Status(EStatus.Wind, duration));
	}
}