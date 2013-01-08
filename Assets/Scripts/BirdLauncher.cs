using UnityEngine;
using System.Collections;

public class BirdLauncher : MonoBehaviour
{
	// Inspector-accessible variables.
	public int _DefaultBirdCount;
	public enum stationList 	{
									random,
									high,
									low
								};
	
	// Inspector-accessible asset variables.
	public GameObject bird;
	public AudioClip changeStation;
	public AudioClip increase;
	public AudioClip decrease;
	
	// Internal variables.
	private static int birdCount;
	private Vector3 highStation;
	private Vector3 lowStation;
	private static stationList selectedStation;
	private Vector3 spawnPosition;

	void Start ()
	{
		birdCount = _DefaultBirdCount;
		selectedStation = stationList.random;
		
		highStation = GameObject.Find ("High Station").transform.position;
		lowStation = GameObject.Find ("Low Station").transform.position;
	}
	
	public void launch ()
	{
		for (int i = 0; i<birdCount; i++)
		{
			switch (selectedStation) {
				case stationList.random:
					spawnPosition = ExtRandom<bool>.EvenChance() ? highStation : lowStation;
					break;
				case stationList.high:
					spawnPosition = highStation;
					break;
				case stationList.low:
					spawnPosition = lowStation;
					break;
			}
			
			Instantiate (bird, spawnPosition, Quaternion.Euler (45, 0, 0));
			spawnPosition = Vector3.zero;
		}
	}
	
	// Housekeeping methods.
	public static int getBirdCount ()
	{
		return birdCount;
	}
	
	public void incrementBirdCount ()
	{
		if (birdCount < 100)
		{
			audio.PlayOneShot(increase);
			birdCount++;
		}
	}
	
	public void decrementBirdCount ()
	{
		if (birdCount > 1)
		{
			audio.PlayOneShot(decrease);
			birdCount--;
		}
	}
	
	public static stationList getStation ()
	{
		return selectedStation;
	}
	
	public void setStation (stationList newStation)
	{
		audio.PlayOneShot(changeStation);
		selectedStation = newStation;
	}
}
