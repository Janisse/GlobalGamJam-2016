using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextTween : MonoBehaviour
{
	#region Properties
	public float minSize = 0.8f;
	public float maxSize = 1f;
	public float frequency = 1f;

	private float currentTime = 0f;
	#endregion

	#region Class methods
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime * frequency;
		float lerpValue = Mathf.Lerp (minSize, maxSize, ((Mathf.Sin (currentTime * 6.2832f) + 1f) / 2f));
		transform.localScale = new Vector3(lerpValue, lerpValue, transform.localScale.z);
	}
	#endregion
}
