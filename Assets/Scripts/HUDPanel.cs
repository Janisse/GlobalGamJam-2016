using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUDPanel : MonoBehaviour
{
	#region Properties
	[Range(0f, 1f)]
	public float gaugeValue = 1f;
	public int nbPart = 3;
	public float maxGaugeWidth = 290f;
	public Transform gaugeContainer = null;
	public RectTransform gaugeTransform = null;
	public Image image = null;
	public GameObject gaugeSeparation = null;

	private List<GameObject> gaugeSeparationList = null;
	#endregion

	#region Class Methods
	// Use this for initialization
	void Start ()
	{
		CreateGauges (nbPart);
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateGauge (gaugeValue);	//PlaceHolder
	}
	#endregion

	#region HUD Methods
	internal void CreateGauges(int a_nbPart)
	{
		//Clear
		if(gaugeSeparationList != null)
		{
			foreach(GameObject obj in gaugeSeparationList)
			{
				Destroy(obj);
			}
			gaugeSeparationList.Clear ();
		}
		else
		{
			gaugeSeparationList = new List<GameObject> ();
		}

		//Instantiate
		for(int i=1; i<a_nbPart; i++)
		{
			GameObject newGaugeGO = (GameObject)Instantiate(gaugeSeparation);
			RectTransform gaugeTrsf = newGaugeGO.GetComponent<RectTransform>();
			gaugeTrsf.SetParent(gaugeContainer);
			gaugeTrsf.anchorMin = new Vector2 (0f, 0.5f);
			gaugeTrsf.anchorMax = new Vector2 (0f, 0.5f);
			gaugeTrsf.pivot = new Vector2 (0f, 0.5f);
			gaugeTrsf.localPosition = new Vector3 (i * (maxGaugeWidth / a_nbPart), 0f, 0f);
		}
	}

	internal void UpdateGauge (float a_gaugeValue)
	{
		gaugeTransform.sizeDelta = new Vector2 (a_gaugeValue * maxGaugeWidth, gaugeTransform.sizeDelta.y);
	}
	#endregion
}
