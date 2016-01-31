using UnityEngine;
using System.Collections;

public class FireSpell : Spell
{
	public GameObject fireBallPrefab = null;
	public float duration = 3f;
	void Start ()
	{
		type = ESpells.Fire;
	}

	internal override void LaunchEffect (PlayerCharacter Player)
	{
		base.LaunchEffect (Player);
		GameMode.instance.player.StatusManager.AddStatus(Status.Make(EStatus.Fire, duration));	//Add FireFX

		if (Player.motor.m_FacingRight)
		{
			GameObject fireBall = (GameObject)Instantiate(fireBallPrefab, Player.transform.position + Vector3.right * 1.5f, Quaternion.identity);
			(fireBall.GetComponent<FireBall> ()).direction = new Vector3 (1f, 0f, 0f);
		}
		else
		{
			GameObject fireBall = (GameObject)Instantiate(fireBallPrefab, Player.transform.position + Vector3.left * 1.5f, Quaternion.identity);
			(fireBall.GetComponent<FireBall> ()).direction = new Vector3 (-1f, 0f, 0f);
		}
	}
}
