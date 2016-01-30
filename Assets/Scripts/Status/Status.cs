using UnityEngine;
using System.Collections;

public enum EStatus
{
	Fire,
	Water,
	Wind
}

[System.Serializable]
public class Status
{
	public EStatus Type = EStatus.Fire;
	[Tooltip("If <= 0, won't time out.")]
	public float duration = 2f;

	protected float _timeElapsed;

	internal virtual bool ShouldTimeout(float a_timeElapsed)
	{
		_timeElapsed += a_timeElapsed;
		if (duration > 0f)
			return _timeElapsed > duration;
		else
			return false;
	}
}
