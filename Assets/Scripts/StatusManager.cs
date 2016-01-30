using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StatusManager
{
	internal List<Status> Status = new List<Status> ();

	internal void Update()
	{
		List<Status> RemovedStatus = new List<Status> ();
		foreach (Status CurrentStatu in Status)
		{
			CurrentStatu.duration -= Time.deltaTime;
			if (CurrentStatu.duration <= 0f)
			{
				RemovedStatus.Add(CurrentStatu);
			}
		}
		foreach (Status CurrentRemovedStatu in RemovedStatus)
		{
			Status.Remove(CurrentRemovedStatu);
		}
	}

	internal void AddStatu (Status NewStatu)
	{
		if (NewStatu.Type == EStatus.Water)
		{
			foreach (Status CurrentStatu in Status)
			{
				if (CurrentStatu.Type == EStatus.Fire)
				{
					Status.Remove(CurrentStatu);
				}
			}
		}
		Status.Add(NewStatu);
	}

	internal void AddStatu (EStatus Type, float duration)
	{
		Status NewStatu = new Status();
		NewStatu.Type = Type;
		NewStatu.duration = duration;
		Status.Add(NewStatu);
	}

	internal bool CheckStatu (EStatus Type)
	{
		foreach (Status CurrentStatu in Status)
		{
			if (CurrentStatu.Type == Type)
			{
				return true;
			}
		}
		return false;
	}
}
