using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Gauge : MonoBehaviour
{
	#region properties
	[Range(0f, 1f)]
	public float gaugeValue = 1f;
	public float[] timeValues = null;
	public float maxGaugeWidth = 290f;
	public Transform gaugeContainer = null;
	public RectTransform gaugeTransform = null;
	public Image image = null;
	public GameObject gaugeSeparation = null;

	internal float totalTime = 0f;

	private List<GameObject> _gaugeSeparationDict = new List<GameObject> ();
	private int _step = 0;
	#endregion

	#region HUD Methods
	internal void CreateGauges()
	{
		//Clear
		foreach(GameObject obj in _gaugeSeparationDict)
		{
			Destroy(obj);
		}
		_gaugeSeparationDict.Clear ();
		_step = 0;

		//Compute gauge duration
		totalTime = 0f;
		for(int i=0; i<timeValues.Length; i++)
		{
			totalTime += timeValues [i];
		}

		//Instantiate
		float currentTime = 0f;
		for(int i=0; i<timeValues.Length-1; i++)
		{
			GameObject newGaugeGO = (GameObject)Instantiate(gaugeSeparation);
			RectTransform gaugeTrsf = newGaugeGO.GetComponent<RectTransform>();
			gaugeTrsf.SetParent(gaugeContainer);
			gaugeTrsf.anchorMin = new Vector2 (0f, 0.5f);
			gaugeTrsf.anchorMax = new Vector2 (0f, 0.5f);
			gaugeTrsf.pivot = new Vector2 (0f, 0.5f);

			//Formule Separator placement
			currentTime += + timeValues[i];
			float placeX = (currentTime / totalTime) * maxGaugeWidth;
			gaugeTrsf.localPosition = new Vector3 (placeX, 0f, 0f);

			_gaugeSeparationDict.Add (newGaugeGO);
		}
	}

	internal bool UpdateGauge (float a_time)
	{
		float a_gaugeValue = Mathf.Clamp01(a_time / totalTime);
		gaugeTransform.sizeDelta = new Vector2 (a_gaugeValue * maxGaugeWidth, gaugeTransform.sizeDelta.y);

		//Check if Next Step
		float value = 0f;
		for(int i=0; i<timeValues.Length; i++)
		{
			value += timeValues [i];
			if(a_time <= value)
			{
				if(_step != i)
				{
					_step = i;
					return true;
				}
				else
				{
					return false;
				}
			}
		}
		return false;
	}
	#endregion
}
