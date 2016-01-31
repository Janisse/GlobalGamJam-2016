using UnityEngine;
using System.Collections;

public class BunnyHopSpell : Spell
{
	float duration = 2f;
	void Start ()
	{
		type = ESpells.BunnyHop;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		GameMode.instance.player.StatusManager.AddStatus(new Status(EStatus.BunnyHop, duration));
	}
}
