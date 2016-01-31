using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	#region Properties
	public Transform target = null;
	public float moveSpeed = 0.1f;
	#endregion

	#region class Methods
	void Awake()
	{
		SnapToTarget();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += new Vector3 ( (target.position.x - transform.position.x) * moveSpeed,
											(target.position.y - transform.position.y) * moveSpeed,
											0f);
	}

	internal void SnapToTarget()
	{
		transform.position = new Vector3 (target.position.x,
										target.position.y,
										transform.position.z);
	}
	#endregion
}
