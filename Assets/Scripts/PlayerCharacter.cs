using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCharacter : MonoBehaviour
{
	#region properties
	public PlatformerMotor motor;
	public SpellManager SpellManager = new SpellManager();
	#endregion

	#region Properties
	internal StatusManager StatusManager = new StatusManager();
	protected bool _shouldJump;
	#endregion

	#region Class methods
	private void Update()
	{
		StatusManager.Update();
		//Change Power
		if(Input.GetKey(KeyCode.R))
		{
			SpellManager.RandomSpell();
		}

		if(Input.GetKey(KeyCode.E))
		{
			SpellManager.LaunchCurrentSpell();
			GameMode.instance.gaugeTime = 0f;
		}
			
		// Read the jump input in Update so button presses aren't missed.
		_shouldJump = CrossPlatformInputManager.GetButton("Jump");
	}

	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		motor.Move(h, _shouldJump);
	}
	#endregion

	#region Player Methods
	internal void ChangeSpell()
	{
	}
	#endregion
}
