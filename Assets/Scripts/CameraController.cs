using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	#region Properties
	public Transform target = null;
	public float moveSpeed = 0.1f;
	#endregion

	#region class Methods
	// Update is called once per frame
	void Update ()
	{
		transform.position += new Vector3 (	(target.position.x - transform.position.x) * moveSpeed,
											(target.position.y - transform.position.y) * moveSpeed,
											0f);
	}
	#endregion
}
