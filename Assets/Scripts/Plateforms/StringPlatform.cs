using UnityEngine;
using System.Collections;

public class StringPlatform : FallenPlatform {

	public SpriteRenderer String = null;

	protected override void Update ()
	{
		if (Fallen)
		{
			Color Color = String.color;
			Color.a -= FadeOutSpeed*Time.deltaTime;
			String.color = Color;
			if(Color.a <= 0f) Destroy(gameObject);
		}
		base.Update ();
	}

	internal override void OnTriggerEnter2D (Collider2D col)
	{
		if( col.gameObject.GetComponent<PlayerCharacter>().StatusManager.CheckStatus(EStatus.Fire))
		{
			base.OnTriggerEnter2D(col);
		}
	}
}
