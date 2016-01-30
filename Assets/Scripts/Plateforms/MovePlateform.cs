using UnityEngine;
using System.Collections;

public class MovePlateform : MonoBehaviour
{
	#region Properties
	public Vector3 moveVector = Vector3.zero;
	public float moveSpeed = 1f;
	public Collider2D col = null;

	private Vector3 initPos = Vector3.zero;
	private Vector3 lastMove = Vector3.zero;
	private Transform PlayerTouching = null;
	#endregion

	#region Class methods
	void Awake()
	{
		initPos = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		float lerpValue = (Mathf.Cos(Time.time * 6.2832f * moveSpeed) + 1f) / 2f;
		lastMove = transform.position;
		transform.position = Vector3.Lerp (initPos, initPos + moveVector, lerpValue);
		lastMove = transform.position - lastMove;

		if(PlayerTouching != null)
		{
			PlayerTouching.position += lastMove;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
			PlayerTouching = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "Player")
		{
			PlayerTouching = null;
		}
	}
	#endregion

	#region Inspector
	#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, transform.position + moveVector);
	}
	#endif
	#endregion
}
