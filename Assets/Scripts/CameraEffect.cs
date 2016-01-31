using UnityEngine;
using System.Collections;

public class CameraEffect : MonoBehaviour {

	public Camera Cam = null;
	public float speedFieldOfView = 1f;
	float fieldOfView = 0f;
	public float fieldOfViewBegin = 10f;
	void Start ()
	{
		fieldOfView = Cam.fieldOfView;
	}
	// Update is called once per frame
	void Update ()
	{
		if (fieldOfView > Cam.fieldOfView)
		{
			Cam.fieldOfView += Time.deltaTime * speedFieldOfView;
			if (fieldOfView < Cam.fieldOfView)
			{
				Cam.fieldOfView = fieldOfView;
			}
		}
	}

	internal void SpawnEffect ()
	{
		Cam.fieldOfView = fieldOfViewBegin;
	}
}
