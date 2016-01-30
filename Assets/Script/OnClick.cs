using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
	}
}
