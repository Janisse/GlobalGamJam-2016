using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

	public List<Spell> Spells = new List<Spell> ();
	public GameObject Player = null;
	Spell CurrentSpell = null;

	internal void RandomSpell ()
	{
		Spell NewSpell = null;
		do
		{
			NewSpell = Spells[Random.Range(0,Spells.Count)];
		}
		while (CurrentSpell == NewSpell);
	}

	internal void LaunchCurrentSpell ()
	{
		CurrentSpell.LaunchEffect(Player);
	}
}