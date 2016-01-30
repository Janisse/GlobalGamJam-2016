using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
	#region properties
	public GameMode gameMode = null;
	public SpellManager SpellManager = null;
	public int currentSpell = 0;
	#endregion

	#region Class methods
	private void FixedUpdate()
	{
		//Change Power
		if(Input.GetKey(KeyCode.A))
		{
			SpellManager.RandomSpell();
		}
		if(Input.GetKey(KeyCode.E))
		{
			SpellManager.LaunchCurrentSpell();
			gameMode.gaugeTime = 0f;
		}
	}
	#endregion

	#region Player Methods
	internal void ChangeSpell()
	{
		SpellManager.RandomSpell();
	}
	#endregion
}