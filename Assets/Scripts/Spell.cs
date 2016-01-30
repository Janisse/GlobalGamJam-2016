using UnityEngine;
using System.Collections;

abstract public class Spell : MonoBehaviour
{
	public GameObject Player = null;
	Sprite Icon = null;

	internal virtual void LaunchEffect ()
	{

	}
}