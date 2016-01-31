using UnityEngine;
using System.Collections;

public class Resetable : MonoBehaviour {

	Vector3 initPosition = new Vector3 ();
	Quaternion initRotation= new Quaternion ();
	Vector3 initScale = new Vector3 ();
	// Use this for initialization
	void Start () {
		initPosition = transform.position;
		initRotation = transform.rotation;
		initScale = transform.localScale;
	}
	
	internal virtual void Reset ()
	{
		transform.position = initPosition;
		transform.rotation = initRotation;
		transform.localScale = initScale;
		gameObject.SetActive(true);
	}
}
