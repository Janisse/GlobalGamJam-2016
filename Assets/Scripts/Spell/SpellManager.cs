using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpellManager : MonoBehaviour {

	public List<Spell> Spells = new List<Spell> ();
	public PlayerCharacter Player = null;
	public Image spellImage = null;
	Spell CurrentSpell = null;

	internal void RandomSpell ()
	{
		Spell NewSpell = null;
		do
		{
			NewSpell = Spells[Random.Range(0,Spells.Count)];
		}
		while (CurrentSpell == NewSpell);
		CurrentSpell = NewSpell;
		spellImage.sprite = CurrentSpell.Icon;
	}

	internal void LaunchCurrentSpell ()
	{
		if (CurrentSpell == null)
			RandomSpell();
		CurrentSpell.LaunchEffect(Player);
	}
}