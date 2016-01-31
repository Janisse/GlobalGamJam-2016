using UnityEngine;
using System.Collections;

public class MusicCrossFadeManager : MonoBehaviour
{
    public AudioSourceVolume[] settings = null;

    internal void SetRatio(float a_ratio)
    {
        foreach (AudioSourceVolume each in settings)
        {
            SetRatio(a_ratio);
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