using UnityEngine;
using System.Collections;

public class CharacterAnimEventCatcher : MonoBehaviour
{
    public AudioSourceBatch footstepAS = null;

	void footstep ()
    {
        footstepAS.Play();
	}
}
