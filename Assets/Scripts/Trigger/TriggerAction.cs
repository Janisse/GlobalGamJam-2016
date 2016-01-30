using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour
{
	#region properties
	private bool isTrigger = false;
	#endregion

	#region Class methods
	void Update()
	{
		if(isTrigger)
			OnStay ();
	}
	#endregion

	#region TriggerAction Methods
	internal void OnEnter()
	{
		if(!isTrigger)
			Debug.Log ("Enter");
		isTrigger = true;
	}

	internal void OnStay()
	{
		Debug.Log ("Stay");
	}

	internal void OnExit()
	{
		if(isTrigger)
			Debug.Log ("Exit");
		isTrigger = false;
	}
	#endregion
}
