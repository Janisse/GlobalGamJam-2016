using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
	public CanvasGroup canvasGroup = null;
	public float duration = 1f;

	protected float _timeElapsed = 0f;
	protected bool transitionActive = false;

	// Update is called once per frame
	void Update ()
	{
		if (transitionActive)
		{
			_timeElapsed += Time.deltaTime;
			canvasGroup.alpha = Mathf.Clamp01(_timeElapsed / duration);
		}
	}

	internal void Play()
	{
		transitionActive = true;
	}
}
