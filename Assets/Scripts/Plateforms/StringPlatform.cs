using UnityEngine;
using System.Collections;

public class StringPlatform : FallenPlatform {

	public SpriteRenderer String = null;

	protected override void Update ()
	{
		if (Fallen)
		{
			Color Colortemp = String.color;
			Colortemp.a -= FadeOutSpeed*Time.deltaTime;
			String.color = Colortemp;
			if(Colortemp.a <= 0f) String.gameObject.SetActive(false);
		}
		base.Update ();
	}

	internal override void OnTriggerEnter2D (Collider2D col)
	{
		PlayerCharacter PC = col.gameObject.GetComponent<PlayerCharacter>();
		if(PC != null && PC.StatusManager.CheckStatus(EStatus.Fire))
		{
			Fallen = true;
		}
	}

	internal override void Reset ()
	{
		Color Colortemp = String.color;
		Colortemp.a = 1f;
		String.color = Colortemp;
		String.gameObject.SetActive(true);
		base.Reset ();
	}
}
