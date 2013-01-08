using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	// Inspector-accessible variables.
	public int _gameLength;
	
	// Inspector-accessible asset variables.
	public AudioClip airhorn;
	
	// Internal variables.
	private int hitBirds;
	private int launchedBirds;
	private float gameTimer;
	private int intTimer;
	private bool gameIsRunning;
	private string stationDisplay;

	void Start ()
	{
		resetGame ();
	}
	
	void Update ()
	{
		if (gameIsRunning == true)
		{
			gameTimer -= Time.deltaTime;
			if (gameTimer <= 0)
			{
				setGameIsRunning(false);
			}
		}
		
		setHUDText ("Bird Count Display", "-  " + BirdLauncher.getBirdCount() +"  +");
		
		intTimer = (int) gameTimer;
		
		setHUDText ("Timer Display", "Time remaining: " + intTimer.ToString ("D2") + "s");
		setHUDText ("Hit Display", "Hit " + hitBirds +" of " + launchedBirds);
		
		switch (BirdLauncher.getStation())
		{
			case BirdLauncher.stationList.random:
				stationDisplay = "[Numpad 4] Random [Numpad 6]";
				break;
			case BirdLauncher.stationList.low:
				stationDisplay = "[Numpad 4] [Numpad 5] Low";
				break;
			case BirdLauncher.stationList.high:
				stationDisplay = "High [Numpad 5] [Numpad 6]";
				break;
		}	
		
		setHUDText ("Station Display", stationDisplay);
	}
	
	// Housekeeping methods.
	public void resetGame ()
	{
		hitBirds = 0;
		launchedBirds = 0;
		gameTimer = _gameLength;
	}
	
	public void incrementHitBirds ()
	{
		hitBirds++;
	}
	
	public void incrementLaunchedBirds ()
	{
		launchedBirds++;
	}
	
	public int getHitBirds ()
	{
		return hitBirds;
	}
	
	public int getLaunchedBirds ()
	{
		return launchedBirds;
	}
	
	public float getGameTimer ()
	{
		return gameTimer;
	}
	
	public bool getGameIsRunning ()
	{
		return gameIsRunning;
	}
	
	public void setGameIsRunning (bool newValue)
	{
		audio.PlayOneShot(airhorn);
		gameIsRunning = newValue;
	}
	
	public static void setHUDText (string objName, string displayedText)
	{
		GameObject.Find(objName).guiText.text = displayedText;
	}
}
