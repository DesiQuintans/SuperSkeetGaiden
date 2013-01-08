using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
	// Inspector-accessible variables.
	
	// Inspector-accessible asset variables.
	public Texture2D crosshairTexture;
	public Shotgun shotgun;
	public BirdLauncher birdlauncher;
	
	// Internal variables.
	private Rect position;
	private GameLogic gamelogic;
	private float reloadTimer;
	
	void Start ()
	{
		gamelogic = GameObject.Find("Logic").GetComponent<GameLogic>();
		shotgun = GetComponent<Shotgun>();
		birdlauncher = GetComponent<BirdLauncher>();
		position = new Rect ((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width/2, crosshairTexture.height/2);
	}
	
	void OnGUI ()
	{
		GUI.DrawTexture (position, crosshairTexture);
	}
	
	void Update ()
	{
		if (Input.anyKeyDown == true)
		{
			if (gamelogic.getGameIsRunning () == true)
			{
				// Shotgun
				if (Input.GetMouseButtonDown(0))
					shotgun.fire ();
				
				if (Input.GetKey(KeyCode.R))
					shotgun.reload ();
					
				// Bird launcher
				if (Input.GetKey(KeyCode.Space))
					birdlauncher.launch ();
			}
					
			if (Input.GetKey (KeyCode.KeypadPlus) || Input.GetKey (KeyCode.Plus)) 
				birdlauncher.incrementBirdCount ();
				
			if (Input.GetKey (KeyCode.KeypadMinus) || Input.GetKey (KeyCode.Minus))
				birdlauncher.decrementBirdCount ();
			
			if (Input.GetKey (KeyCode.Keypad4))
				birdlauncher.setStation(BirdLauncher.stationList.high);
				
			if (Input.GetKey (KeyCode.Keypad5))
				birdlauncher.setStation(BirdLauncher.stationList.random);
				
			if (Input.GetKey (KeyCode.Keypad6))
				birdlauncher.setStation(BirdLauncher.stationList.low);
					
			// Game logic
			if (Input.GetKey (KeyCode.End))
			{
				gamelogic.resetGame ();
				gamelogic.setGameIsRunning (true);
				birdlauncher.launch ();
			}
		}
	}
}
