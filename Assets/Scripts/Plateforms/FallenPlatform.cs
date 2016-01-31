using UnityEngine;
using System.Collections;

public class FallenPlatform : Resetable {

	public Collider2D Colid = null;
	public Rigidbody2D Rigidbody = null;
	public float delais = 0.5f;
	float currentDelais = 0f;
	protected bool Fallen = false;
	public SpriteRenderer platformSprite = null;
	public float FadeOutSpeed = 0.8f;
	public AudioSource SoundFall = null;
	// Update is called once per frame
	virtual protected void Update ()
	{
		if (Fallen)
		{
			currentDelais+=Time.deltaTime;
			if (currentDelais >= delais)
			{
				Colid.enabled = false;
				Rigidbody.isKinematic = false;
				Color Color = platformSprite.color;
				Color.a -= FadeOutSpeed*Time.deltaTime;
				platformSprite.color = Color;
				if(Color.a <= 0f) gameObject.SetActive(false);
			}
		}
	}

	virtual internal void OnTriggerEnter2D(Collider2D col)
	{
		PlayerCharacter PC = col.gameObject.GetComponent<PlayerCharacter>();
		if(PC != null)
		{

			SoundFall.Play();
			Fallen = true;
		}
	}
	internal override void Reset ()
	{
		Color ColorTemp = platformSprite.color;
		ColorTemp.a = 1f;
		platformSprite.color = ColorTemp;
		Colid.enabled = true;
		Rigidbody.isKinematic = true;
		Fallen = false;
		currentDelais = 0f;
		base.Reset ();
	}
}
