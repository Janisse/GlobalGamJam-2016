using UnityEngine;
using System.Collections;

public class ParallaxLayer : MonoBehaviour
{
	#region Inspector Properties
	[Range(0f, 5f)]
	public float layerDistanceMultiplierX = 1f;

	[Range(0f, 5f)]
	public float layerDistanceMultiplierY = 1f;
	#endregion

	internal void SetParallaxOffset(Vector2 a_offset)
	{
		Vector3 position = transform.localPosition;
		position.x = a_offset.x * (1f - layerDistanceMultiplierX);
		position.y = a_offset.y * (1f - layerDistanceMultiplierY);
		transform.localPosition = position;
	}
}