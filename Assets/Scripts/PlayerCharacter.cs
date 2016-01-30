using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCharacter : MonoBehaviour
{
	#region properties
	public PlatformerMotor motor;
	public GameMode gameMode = null;
	public SpellManager SpellManager = null;
	#endregion

	#region Properties
	internal StatusManager StatusManager = new StatusManager();
	protected bool _shouldJump;
	#endregion

	#region Class methods
	private void Update()
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

		if (!_shouldJump)
		{
			// Read the jump input in Update so button presses aren't missed.
			_shouldJump = CrossPlatformInputManager.GetButtonDown("Jump");
		}
	}

	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		motor.Move(h, _shouldJump);
		_shouldJump = false;
	}
	#endregion

	#region Player Methods
	internal void ChangeSpell()
	{
	}
	#endregion
}
