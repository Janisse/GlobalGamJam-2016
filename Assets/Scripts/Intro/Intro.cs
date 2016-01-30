using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Intro : MonoBehaviour
{
	#region properties
	public CanvasGroup[] groups = null;
	public float timeBtwImages = 2f;
	public float transitionDuration = 0.2f;

	private float currentTime = 0f;
	#endregion

	#region Class methods
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		int curImage = Mathf.FloorToInt(currentTime / timeBtwImages);
		if(curImage < groups.Length)
		{
			if(Input.anyKeyDown)
			{
				currentTime = timeBtwImages * (curImage + 1);
			}

			for(int i=0; i<groups.Length; i++)
			{
				if(curImage == i)
				{
					groups [i].alpha = Mathf.Clamp01(groups [i].alpha + (Time.deltaTime / transitionDuration));
				}
				else
				{
					groups [i].alpha = Mathf.Clamp01(groups [i].alpha - (Time.deltaTime / transitionDuration));
				}
			}
		}
		else
		{
			if(Input.anyKeyDown)
			{
				SceneManager.LoadScene ("Level 1", LoadSceneMode.Single);
			}
		}
	}
	#endregion
}
