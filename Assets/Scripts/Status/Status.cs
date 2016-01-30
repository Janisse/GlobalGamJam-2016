using UnityEngine;
using System.Collections;

public enum EStatus
{
	Fire,
	Water,
	Wind
}

internal class Status {

	internal EStatus Type = EStatus.Fire;
	internal float duration = 2f;
}
