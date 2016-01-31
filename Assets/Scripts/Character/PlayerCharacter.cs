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
	public float DelayKill = 2f; 
	public CameraEffect CamEffect = null;
	public ParticleSystem fireParticles = null;
	public ParticleSystem WindParticles = null;
	public AudioSource RespawnSound = null;
	#endregion

	#region Properties
	internal StatusManager StatusManager = new StatusManager();
	protected bool _shouldJump;
	float currentDelay = 0f;
	bool KillMePlease = false;
	float timerKill = 0f;
	bool FreezeInput = false;
	#endregion

	#region Class methods
	void Start()
	{
		fireParticles.Stop ();
		WindParticles.Stop ();
		spellManager.RandomSpell ();
	}

	private void Update()
	{
		StatusManager.Update();

		if(StatusManager.CheckStatus (EStatus.Fire) && !fireParticles.isPlaying)
			fireParticles.Play ();
		else if(!StatusManager.CheckStatus (EStatus.Fire))
			fireParticles.Stop ();

		if(StatusManager.CheckStatus (EStatus.Wind) && !WindParticles.isPlaying)
			WindParticles.Play ();
		else if(!StatusManager.CheckStatus (EStatus.Wind))
			WindParticles.Stop ();

		if(KillMePlease)
		{
			timerKill += Time.deltaTime;
			if(timerKill >= DelayKill)
			{
				KillMePlease = false;
				FreezeInput = false;
				motor.SetAnim("Idle");
				timerKill = 0f;
				Respawn();
			}
		}

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

		if (StatusManager.CheckStatus (EStatus.BunnyHop))
			_shouldJump = true;
		else
			_shouldJump = CrossPlatformInputManager.GetButton("Jump");
	}

	private void FixedUpdate()
	{
		// Read the inputs.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		if(!FreezeInput)
		{
			if (StatusManager.CheckStatus (EStatus.Nausea))
				motor.Move(-h, _shouldJump);
			else
				motor.Move(h, _shouldJump);
		}
		else
			motor.Move(0f, false);
	}
	#endregion

	#region Player Methods
	internal void Kill()
	{
		motor.SetAnim("Death");
		KillMePlease = true;
		FreezeInput = true;
	}


	internal void InstantKill()
	{
		Respawn();
	}

	internal void Respawn()
	{
		RespawnSound.Play();
		CamEffect.SpawnEffect();
		GameMode.instance.ResetableManager.ResetAll ();
		GameMode.instance.SpawnPlayer ();
		GameMode.instance.gaugeTime = 0f;
		motor.modelAnimator.Reset ();
	}
	#endregion
}
