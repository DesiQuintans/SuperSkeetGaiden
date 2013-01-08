using UnityEngine;
using System.Collections;

public class Cleanup : MonoBehaviour {
	
	public float timeToLive;
	
	void Awake ()
	{
		if (timeToLive != 0) {
			Destroy (gameObject, timeToLive);
		}
	}
}
