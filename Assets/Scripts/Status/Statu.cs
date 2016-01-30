using UnityEngine;
using System.Collections;

public enum EStatus
{
	Fire,
	Water,
	Wind
}

internal class Statu : MonoBehaviour {

	internal EStatus Type = EStatus.Fire;
	internal float duration = 2f;
}
