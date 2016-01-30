using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour
{
	#region Inspector Properties
	[Range(0f,5f)]
	public float distanceMultiplierX = 1f;

	[Range(0f,5f)]
	public float distanceMultiplierY = 1f;
	#endregion

	internal void SetParallaxOffset(Vector2 a_offset)
	{
		Vector3 position = transform.localPosition;
		position.x = -a_offset.x * distanceMultiplierX;
		position.y = -a_offset.y * distanceMultiplierY;
		transform.localPosition = position;
	}
}
