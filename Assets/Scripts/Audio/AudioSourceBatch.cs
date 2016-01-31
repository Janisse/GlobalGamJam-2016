using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioSourceBatch : MonoBehaviour
{
    public AudioSource[] sources = null;
    public Vector2 pitchRange = Vector2.one;

    internal void Play()
    {
        List<AudioSource> freeSources = new List<AudioSource>();

        foreach (AudioSource each in sources)
        {
            if (!each.isPlaying)
            {
                freeSources.Add(each);
            }
        }

        if (freeSources.Count > 0)
        {
            int index = Random.Range(0, freeSources.Count);
            freeSources[index].pitch = Random.Range(pitchRange.x, pitchRange.y);
            freeSources[index].Play();
        }
        else
        {
            Debug.LogWarning("Audio source batch : no free audio source.");
        }
    }
}
