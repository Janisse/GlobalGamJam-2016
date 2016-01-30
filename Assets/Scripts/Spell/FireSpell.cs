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
		Debug.Log("Launch Fire Spell");
		GameMode.instance.player.StatusManager.AddStatus(EStatus.Fire,duration);
	}
}
