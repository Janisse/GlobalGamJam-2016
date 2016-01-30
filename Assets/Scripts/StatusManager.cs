using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StatusManager : MonoBehaviour
{
	internal List<Statu> Status = new List<Statu> ();

	void Update()
	{
		foreach (Statu CurrentStatu in Status)
		{
			CurrentStatu.duration -= Time.deltaTime;
		}
	}

	void AddStatu (Statu NewStatu)
	{
		if (NewStatu.Type == EStatus.Water)
		{
			foreach (Statu CurrentStatu in Status)
			{
				if (CurrentStatu.Type == EStatus.Fire)
				{
					Status.Remove(CurrentStatu);
				}
			}
		}
		Status.Add(NewStatu);
	}

	void AddStatu (EStatus Type, float duration)
	{
		Statu NewStatu = new Statu();
		NewStatu.Type = Type;
		NewStatu.duration = duration;
		Status.Add(NewStatu);
	}
}
