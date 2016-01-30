﻿using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour
{
	#region properties
	public PlayerCharacter player = null;
	public Gauge spellGauge = null;
	public float gaugeTime = 1f;
	public Transform LevelStart = null;

	internal Transform currentCheckPoint = null;
	internal int nextSpell = 0;
	#endregion

	#region Getter
	internal static GameMode instance;
	#endregion

	#region Class methods
	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start ()
	{
		spellGauge.CreateGauges ();
		currentCheckPoint = LevelStart;
		SpawnPlayer ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		gaugeTime += Time.deltaTime;
		if(gaugeTime >= spellGauge.totalTime)
		{
			//Pas cool
			//Boom !!!
			player.ChangeSpell();
			gaugeTime = 0f;
			spellGauge.UpdateGauge (gaugeTime);
		}
		else
		{
			if(spellGauge.UpdateGauge (gaugeTime))
			{
//				nextSpell = rnd;	//next Spell
			}
		}
	}
	#endregion

	#region GameMode Methods
	internal int GetNextSpell()
	{
		gaugeTime = 0f;
		return 0;	//next Spell
	}

	internal void SetCheckpoint(Transform a_checkPoint)
	{
		currentCheckPoint = a_checkPoint;
	}

	internal void SpawnPlayer()
	{
		player.transform.position = currentCheckPoint.position;
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
	}
	#endregion
}
