using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour
{
	#region properties
	protected bool isTrigger = false;
	#endregion

	#region Class methods
	void Update()
	{
		if(isTrigger)
			OnStay ();
	}
	#endregion

	#region TriggerAction Methods
	internal virtual void OnEnter()
	{
		if(!isTrigger)
			Debug.Log ("Enter");
		isTrigger = true;
	}

	internal virtual void OnStay()
	{
		Debug.Log ("Stay");
	}

	internal virtual void OnExit()
	{
		if(isTrigger)
			Debug.Log ("Exit");
		isTrigger = false;
	}
	#endregion
}
