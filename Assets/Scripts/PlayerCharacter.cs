using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
	#region properties
	public GameMode gameMode = null;
	public int currentSpell = 0;
	#endregion

	#region Class methods
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void FixedUpdate()
	{
		//Change Power
		if(Input.GetKey(KeyCode.A))
		{
			ChangePower ();
		}
	}
	#endregion

	#region Player Methods
	internal void ChangePower()
	{
		currentSpell = gameMode.GetNextSpell ();
		Debug.Log ("Change Power");
	}
	#endregion
}
