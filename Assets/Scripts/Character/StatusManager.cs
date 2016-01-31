using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StatusManager
{
	internal   Dictionary<int, StatusWrapper> _status = new Dictionary<int, StatusWrapper> ();
	protected  List<StatusWrapper> _toRemoveStatus = new List<StatusWrapper> ();
	protected  List<StatusWrapper> _toAddStatus = new List<StatusWrapper> ();

	protected int statusId = 0;

	internal void Update()
	{
		foreach (StatusWrapper each in _toRemoveStatus)
		{
			_status.Remove (each.id);
		}
		_toRemoveStatus.Clear ();
		foreach (StatusWrapper each in _toAddStatus)
		{
			_status.Add (each.id, each);
		}
		_toAddStatus.Clear ();


		foreach (StatusWrapper CurrentStatu in _status.Values)
		{
			CurrentStatu.status.OnUpdate ();
		}
		CheckForTimeout ();


		//After timeout, OnUpdate & OnRemove ( clear again )
		foreach (StatusWrapper each in _toRemoveStatus)
		{
			_status.Remove (each.id);
		}
		_toRemoveStatus.Clear ();
		foreach (StatusWrapper each in _toAddStatus)
		{
			_status.Add (each.id, each);
		}
		_toAddStatus.Clear ();
	}

	protected void CheckForTimeout()
	{
		foreach (StatusWrapper CurrentStatu in _status.Values)
		{
			if (CurrentStatu.ShouldTimeout (Time.deltaTime))
			{
				RemoveStatus (CurrentStatu);
			}
		}
	}

	internal int AddStatus (Status NewStatu)
	{
		StatusWrapper wrapper = new StatusWrapper (statusId, NewStatu);
		statusId++;

		wrapper.status.OnApply ();
		_toAddStatus.Add (wrapper);

		return wrapper.id;
	}

	internal bool CheckStatus (EStatus Type)
	{
		foreach (StatusWrapper CurrentStatu in _status.Values)
		{
			if (CurrentStatu.status.type == Type)
			{
				return true;
			}
		}
		return false;
	}

	#region Remove
	internal void RemoveStatus(StatusWrapper a_appliedStatus)
	{
		RemoveStatus (a_appliedStatus.id);
	}

	internal void RemoveStatus(int a_id)
	{
		if (_status.ContainsKey(a_id))
		{
			_toRemoveStatus.Add (_status[a_id]);
			_status[a_id].status.OnRemove ();
		}
	}
	#endregion

	internal void ClearAllStatus(EStatus a_type)
	{
		foreach (StatusWrapper CurrentStatus in _status.Values)
		{
			if (CurrentStatus.status.type == a_type)
			{
				RemoveStatus (CurrentStatus);
			}
		}
	}
}

public class StatusWrapper
{
	public Status status;
	public int id;
	public float _timeElapsed = 0f;

	internal StatusWrapper(int a_id, Status a_status)
	{
		id = a_id;
		status = a_status;
	}

	internal virtual bool ShouldTimeout(float a_timeElapsed)
	{
		_timeElapsed += a_timeElapsed;
		if (status.duration > 0f)
			return _timeElapsed > status.duration;
		else
			return false;
	}

}