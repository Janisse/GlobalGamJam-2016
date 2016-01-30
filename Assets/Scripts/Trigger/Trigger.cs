using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
	#region Properties
	public TriggerAction[] actionsOnEnter = null;
	public TriggerAction[] actionsOnExit = null;
	#endregion

	#region Class Methods
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			foreach(TriggerAction action in actionsOnEnter)
			{
				action.OnEnter ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			foreach(TriggerAction action in actionsOnEnter)
			{
				action.OnExit ();
			}
		}
	}
	#endregion
}
