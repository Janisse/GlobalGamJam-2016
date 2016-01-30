using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
internal class ParallaxController : MonoBehaviour
{
	public ParallaxManager parallaxManager = null;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (parallaxManager != null) 
		{
			parallaxManager.SetParallaxOffset (new Vector2 (transform.localPosition.x,
				transform.localPosition.y));
		}
	}
}
