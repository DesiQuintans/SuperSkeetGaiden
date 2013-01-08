using UnityEngine;
using System.Collections;

// This class provides getters and setters to modify and maintain the game-specific variables of the
// player (health, ammo and so on).

public class Shotgun : MonoBehaviour
{
	// Inspector-accessible variables.
	public int _ProjectilesPerShot;
	public int _MagSize;
	public int _LoadedAmmo;
	public float _reloadDelay;
	
	// Inspector-accessible asset variables.
	public GameObject projectile;
	public AudioClip fireSound;
	public AudioClip emptySound;
	public AudioClip reloadSound;
	
	// Internal variables.
	private int projectilesPerShot;
	private int magSize;
	private int loadedAmmo;
	private float reloadDelay;
	private float reloadTimer;
	
	void Start ()
	{
		projectilesPerShot = _ProjectilesPerShot;
		magSize = _MagSize;
		loadedAmmo = _LoadedAmmo;
		reloadDelay = _reloadDelay;
		reloadTimer = Time.time;
	}
	
	public void fire ()
	{
		if (loadedAmmo > 0)
		{
			loadedAmmo--;
			audio.PlayOneShot (fireSound);
			for (int i = 0; i<projectilesPerShot; i++)
			{
				Instantiate (projectile, gameObject.transform.position, Quaternion.identity);
			}
		}
		else
		{
			audio.PlayOneShot (emptySound);
		}
	}
	
	public void reload ()
	{
		if (Time.time >= reloadTimer + reloadDelay)
		{
			if (loadedAmmo < magSize)
			{
				audio.PlayOneShot (reloadSound);
				loadedAmmo++;
				reloadTimer = Time.time;
			}
		}
	}
	
	// Housekeeping methods.
	public int getLoadedAmmo ()
	{
		return loadedAmmo;
	}
	
	public void setLoadedAmmo (int num)
	{
		loadedAmmo = num;
	}
}
