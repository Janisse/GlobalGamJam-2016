using UnityEngine;
using System.Collections;

public class FallenPlatform : MonoBehaviour {

	public Collider2D Colid = null;
	public Rigidbody2D Rigidbody = null;
	public float delais = 0.5f;
	float currentDelais = 0f;
	bool Fallen = false;
	// Update is called once per frame
	void Update ()
	{
		if (Fallen)
		{
			currentDelais+=Time.deltaTime;
			if (currentDelais >= delais)
			{
				Colid.enabled = false;
				Rigidbody.isKinematic = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Fallen = true;
	}
}
