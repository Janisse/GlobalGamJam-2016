using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCharacter : MonoBehaviour
{
	#region properties
	public PlatformerMotor motor;
	public GameMode gameMode = null;
	#endregion

	#region Properties
	protected bool _shouldJump;
	#endregion

	#region Class methods
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Change Power
		if(Input.GetKey(KeyCode.A))
		{
			ChangePower ();
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
	internal void ChangePower()
	{
	}
	#endregion





}
