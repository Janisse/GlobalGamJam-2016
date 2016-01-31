using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCharacter : MonoBehaviour
{
	#region inspector properties
	public PlatformerMotor motor;
	public SpellManager spellManager = null;
	[Tooltip("delais avant de pouvoir relancer un sort (le fait de maintenir appuyer n'envois pas les sorts en boucle)")]
	public float DelaySpell = 1f;
	#endregion

	#region Properties
	internal StatusManager StatusManager = new StatusManager();
	protected bool _shouldJump;
	float currentDelay = 0f;
	#endregion

	#region Class methods
	private void Update()
	{
		StatusManager.Update();
		if(currentDelay <= 0)
		{
			if(Input.GetKey(KeyCode.E))
			{
				spellManager.LaunchCurrentSpell();
				currentDelay = DelaySpell;
				GameMode.instance.gaugeTime = -DelaySpell;
			}
		}
		else
		{
			currentDelay -= Time.deltaTime;
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
	internal void Kill()
	{
		GameMode.instance.ResetableManager.ResetAll ();
		GameMode.instance.SpawnPlayer ();
	}
	#endregion
}
