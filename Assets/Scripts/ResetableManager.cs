using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetableManager : MonoBehaviour {

	public List<Resetable> Restables = new List<Resetable> ();

	internal void ResetAll()
	{
		foreach(Resetable R in Restables)
		{
			R.Reset();
		}
	}
}
