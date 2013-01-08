using UnityEngine;
using System.Collections;

public class BirdBehaviour : MonoBehaviour
{
	public float velocity;
	public float spreadX;
	public float spreadY;
	public float spreadZ;
	private GameLogic gamelogic;
	private bool hasBeenHit = false;
	public GameObject dustPuff;
	
	void Awake ()
	{
		gamelogic = GameObject.Find("Logic").GetComponent<GameLogic>();
		gamelogic.incrementLaunchedBirds ();
		
		Vector3 randomDir = ExtRandom<Vector3>.RandomSpread ((GameObject.Find("Bird Aimpoint").transform.position - gameObject.transform.position), spreadX, spreadY, spreadZ);
		rigidbody.AddForce (randomDir.normalized * velocity, ForceMode.Impulse);
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Pellet" && !hasBeenHit) {
			Instantiate (dustPuff, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
			gamelogic.incrementHitBirds ();
			hasBeenHit = true;
		}
	}
}