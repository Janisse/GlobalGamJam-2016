using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour
{
	#region properties
	public float speed = 2f;

	internal Vector3 direction = Vector3.zero;

	private float currentTime = 0f;
	private float lifeTime = 10f;
	#endregion

	#region Class Methods
	void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > lifeTime)
			Destroy (gameObject);

		transform.position += direction * Time.deltaTime * speed;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.tag != "Player")
		Destroy (gameObject);
	}
	#endregion
}
