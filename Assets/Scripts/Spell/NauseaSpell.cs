using UnityEngine;
using System.Collections;

public class NauseaSpell : Spell
{
	float duration = 2f;
	void Start ()
	{
		type = ESpells.Nausea;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		GameMode.instance.player.StatusManager.AddStatus(new Status(EStatus.Nausea, duration));
	}
}
