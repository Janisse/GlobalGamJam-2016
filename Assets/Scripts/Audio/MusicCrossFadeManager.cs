using UnityEngine;
using System.Collections;

public class MusicCrossFadeManager : MonoBehaviour
{
	public float ratio = 0f;
    public AudioSourceVolume[] settings = null;

	void Start()
	{
		foreach (AudioSourceVolume each in settings)
		{
			each.src.Play ();
		}
	}

	void Update()
	{
		SetRatio (ratio);
	}

    internal void SetRatio(float a_ratio)
    {
        foreach (AudioSourceVolume each in settings)
        {
			each.SetRatio(a_ratio);
        }
    }
}

[System.Serializable]
public class AudioSourceVolume
{
    public AudioSource src = null;
    public AnimationCurve volumeCurve = new AnimationCurve();

    internal void SetRatio(float a_ratio)
    {
        src.volume = volumeCurve.Evaluate(a_ratio);
    }
}