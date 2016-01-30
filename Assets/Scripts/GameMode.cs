using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour
{
	#region properties
	public PlayerCharacter player = null;
	public Gauge spellGauge = null;
	public float gaugeTime = 1f;

	internal int nextSpell = 0;
	#endregion

	#region Class methods
	// Use this for initialization
	void Start ()
	{
		spellGauge.CreateGauges ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		gaugeTime += Time.deltaTime;
		if(gaugeTime >= spellGauge.totalTime)
		{
			//Pas cool
			//Boom !!!
			player.ChangePower();
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
	#endregion
}
