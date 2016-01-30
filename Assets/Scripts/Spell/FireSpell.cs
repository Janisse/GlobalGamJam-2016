using UnityEngine;
using System.Collections;

public class FireSpell : Spell
{
	public float duration = 3f;
	void Start ()
	{
		type = ESpells.Fire;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		GameMode.instance.player.StatusManager.AddStatus(Status.Make(EStatus.Fire, duration));
	}
}
