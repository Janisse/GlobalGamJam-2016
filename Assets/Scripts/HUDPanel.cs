using UnityEngine;
using System.Collections;

public class HUDPanel : MonoBehaviour
{
	#region Properties
	public float gaugeTime = 1f;
	public Gauge gauge = null;
	#endregion

	#region Class Methods
	// Use this for initialization
	void Start ()
	{
		gauge.CreateGauges ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool res = gauge.UpdateGauge (gaugeTime);	//PlaceHolder
		Debug.Log(res);		//PlaceHolder
	}
	#endregion
}
