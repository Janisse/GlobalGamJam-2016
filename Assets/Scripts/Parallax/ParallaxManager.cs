using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ParallaxManager : MonoBehaviour
{
	#region Inspector Properties
	public ParallaxLayer[] layers = null;
	#endregion

	internal void SetParallaxOffset(Vector2 a_offset)
	{
		foreach(ParallaxLayer each in layers)
		{
			each.SetParallaxOffset (a_offset);
		}
	}
}