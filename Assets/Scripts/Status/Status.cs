using UnityEngine;
using System.Collections;

public enum EStatus
{
	Fire,
	Wet,
	Wind,
	Nausea,
	BunnyHop
}

[System.Serializable]
public class StatusConf
{
	public EStatus type = EStatus.Fire;
	[Tooltip("If <= 0, won't time out.")]
	public float duration = 2f;
}

public class Status
{
	internal EStatus type = EStatus.Fire;
	internal float duration = 2f;

	protected float _timeElapsed;

	internal Status(EStatus a_type, float a_duration)
	{
		type = a_type;
		duration = a_duration;
	}

	internal virtual void OnApply()
	{
		
	}

	internal virtual void OnUpdate()
	{
		
	}

	internal virtual void OnRemove()
	{
		
	}

	#region Factory
	internal static Status Make(EStatus a_type, float a_duration)
	{
		Status val = null;
		switch (a_type)
		{
			case EStatus.Wet:
			val = new WetStatus (a_type, a_duration);
			break;

			case EStatus.Fire:
			val = new FireStatus (a_type, a_duration);
			break;

			case EStatus.Nausea:
			val = new NauseaStatus (a_type, a_duration);
			break;

			case EStatus.BunnyHop:
			val = new BunnyHopStatus (a_type, a_duration);
			break;

			default:
			val = new Status (a_type, a_duration);
			break;
		}

		return val;
	}

	internal static Status Make(StatusConf a_conf)
	{
		return Make(a_conf.type, a_conf.duration);
	}
	#endregion
}

public class WetStatus : Status
{
	internal WetStatus(EStatus a_type, float a_duration) : base(a_type, a_duration)
	{
	}

	internal override void OnApply ()
	{
		base.OnApply ();
		GameMode.instance.player.StatusManager.ClearAllStatus (EStatus.Fire);
	}

	internal override void OnUpdate ()
	{
		base.OnUpdate ();
		GameMode.instance.player.StatusManager.ClearAllStatus (EStatus.Fire);
	}

	internal override void OnRemove ()
	{
		base.OnRemove ();
		GameMode.instance.player.StatusManager.ClearAllStatus (EStatus.Fire);
	}
}

public class FireStatus : Status
{
	internal FireStatus(EStatus a_type, float a_duration) : base(a_type, a_duration)
	{
	}

	internal override void OnApply ()
	{
		base.OnApply ();
	}

	internal override void OnUpdate ()
	{
		base.OnUpdate ();
	}

	internal override void OnRemove ()
	{
		base.OnRemove ();
		foreach (Spell S in  GameMode.instance.spellManager.Spells)
		{
			if (S.type == ESpells.Fire)
			{
				if (S.SoundLong != null)
					S.SoundLong.Stop();
				break;
			}
		}
	}
}

public class NauseaStatus : Status
{
	internal NauseaStatus(EStatus a_type, float a_duration) : base(a_type, a_duration)
	{
	}

	internal override void OnApply ()
	{
		base.OnApply ();
//		GameMode.instance.player.motor.inversMove = -1f;
	}

	internal override void OnUpdate ()
	{
		base.OnUpdate ();
	}

	internal override void OnRemove ()
	{
		base.OnRemove ();
//		GameMode.instance.player.motor.inversMove = 1f;
	}
}

public class BunnyHopStatus : Status
{
	internal BunnyHopStatus(EStatus a_type, float a_duration) : base(a_type, a_duration)
	{
	}

	internal override void OnApply ()
	{
		base.OnApply ();
//		GameMode.instance.player.motor.isBunnyHop = true;
	}

	internal override void OnUpdate ()
	{
		base.OnUpdate ();
	}

	internal override void OnRemove ()
	{
		base.OnRemove ();
//		GameMode.instance.player.motor.isBunnyHop = false;
	}
}
