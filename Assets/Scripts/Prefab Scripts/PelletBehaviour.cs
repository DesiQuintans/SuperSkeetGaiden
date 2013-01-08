using UnityEngine;
using System.Collections;

public class PelletBehaviour : MonoBehaviour {
	
	public int minMuzzleVelocity;
	public int maxMuzzleVelocity;
	public float spreadX;
	public float spreadY;
	public float spreadZ;
	public GameObject dustPuff;
	
	void Awake ()
	{
		Vector3 randomDir = ExtRandom<Vector3>.RandomSpread(Camera.main.transform.forward, spreadX, spreadY, spreadZ);
		rigidbody.AddForce (randomDir.normalized * Random.Range (minMuzzleVelocity, maxMuzzleVelocity), ForceMode.Impulse);
	}
}