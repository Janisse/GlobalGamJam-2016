using UnityEngine;
using System.Collections;

public class Collectible : TriggerAction
{
	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
		{
//			GameMode.instance.player.DoAction (); !!		//PlaceHolder
			Debug.Log("Cling");
			Destroy(this.gameObject);
		}
		isTrigger = true;
	}
	#endregion
}
