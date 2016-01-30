using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StatusManager
{
	internal List<Status> _status = new List<Status> ();

	internal void Update()
	{
		List<Status> removedStatus = new List<Status> ();
		foreach (Status CurrentStatu in _status)
		{
			if (CurrentStatu.ShouldTimeout(Time.deltaTime))
			{
				removedStatus.Add(CurrentStatu);
			}
		}
		foreach (Status CurrentRemovedStatu in removedStatus)
		{
			_status.Remove(CurrentRemovedStatu);
		}
	}

	internal void AddStatus (Status NewStatu)
	{
		if (NewStatu.Type == EStatus.Water)
		{
			foreach (Status CurrentStatu in _status)
			{
				if (CurrentStatu.Type == EStatus.Fire)
				{
					_status.Remove(CurrentStatu);
				}
			}
		}
		_status.Add(NewStatu);
	}

	internal void AddStatus (EStatus Type, float duration)
	{
		Status NewStatu = new Status();
		NewStatu.Type = Type;
		NewStatu.duration = duration;
		_status.Add(NewStatu);
	}

	internal bool CheckStatus (EStatus Type)
	{
		foreach (Status CurrentStatu in _status)
		{
			if (CurrentStatu.Type == Type)
			{
				return true;
			}
		}
		return false;
	}

	internal void RemoveStatus(Status a_appliedStatus)
	{
		_status.Remove (a_appliedStatus);
	}

	internal void ClearAllStatus(EStatus a_type)
	{
		List<Status> removedStatus = new List<Status> ();
		foreach (Status CurrentStatus in _status)
		{
			if (CurrentStatus.Type == a_type)
			{
				removedStatus.Add(CurrentStatus);
			}
		}
		foreach (Status CurrentRemovedStatu in removedStatus)
		{
			_status.Remove(CurrentRemovedStatu);
		}
	}
}
