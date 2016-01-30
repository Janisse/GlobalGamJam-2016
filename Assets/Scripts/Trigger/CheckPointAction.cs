﻿using UnityEngine;
using System.Collections;

public class CheckPointAction : TriggerAction
{
	#region TriggerAction Methods
	internal override void OnEnter()
	{
		if (!isTrigger)
			GameMode.instance.SetCheckpoint (transform);
		isTrigger = true;
	}
	#endregion
}
