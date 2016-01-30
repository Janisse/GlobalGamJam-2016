using UnityEngine;
using System.Collections;

public class TriggerAction : MonoBehaviour
{
	#region properties
	protected bool isTrigger = false;
	#endregion

	#region Class methods
	void FixedUpdate()
	{
		if(isTrigger)
			OnStay ();
	}
	#endregion

	#region TriggerAction Methods
	internal virtual void OnEnter()
	{
		isTrigger = true;
	}

	internal virtual void OnStay()
	{
	}

	internal virtual void OnExit()
	{
		isTrigger = false;
	}
	#endregion
}
