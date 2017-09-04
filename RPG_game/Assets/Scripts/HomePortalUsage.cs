using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HomePortalUsage : MonoBehaviour {

	private PlayerController thePlayer;
	private TownPortal townPortal;
	private TownPortalUsage townPortalUsage;
	public string exitPoint;
	private MusicController musicController;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		townPortal = FindObjectOfType<TownPortal> ();
		townPortalUsage = FindObjectOfType<TownPortalUsage> ();
		musicController = FindObjectOfType<MusicController> ();
		DontDestroyOnLoad (this);
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			//SceneManager.LoadScene (townPortalUsage.sceneName);//ovako on loada scenu i player bude tamo di je bio po pitanju x-a i y-a u trenutnoj(prijasnjoj) sceni
			ReturnToPreviousScene();
			Destroy (this.gameObject);
		}
	}

	void ReturnToPreviousScene()
	{
		switch (townPortalUsage.sceneName) {

		case "Inn":
			SceneManager.LoadScene ("Inn");
			exitPoint = "Inn In";
			thePlayer.startPoint = exitPoint;
			break;
		
		case "house_inside":
			SceneManager.LoadScene ("house_inside");
			exitPoint = "Test House In";
			thePlayer.startPoint = exitPoint;
			break;

		case "house_inside2":
			SceneManager.LoadScene ("house_inside2");
			exitPoint = "Test House 2 In";
			thePlayer.startPoint = exitPoint;
			break;
		
		case "dungeon":
			SceneManager.LoadScene ("dungeon");
			exitPoint = "Dungeon test in";
			thePlayer.startPoint = exitPoint;
			musicController.SwitchTrack (1);
			break;
		
		case "dungeon_2":
			SceneManager.LoadScene ("dungeon_2");
			exitPoint = "Dungeon_2 entry";
			thePlayer.startPoint = exitPoint;
			musicController.SwitchTrack (1);
			break;

		case "dungeon_3":
			SceneManager.LoadScene ("dungeon_3");
			exitPoint = "dungeon_3 entry";
			thePlayer.startPoint = exitPoint;
			musicController.SwitchTrack (1);
			break;

		case "castle_1":
			SceneManager.LoadScene ("castle_1");
			exitPoint = "Castle Entry";
			thePlayer.startPoint = exitPoint;
			break;
		
		case "castle_2":
			SceneManager.LoadScene ("castle_2");
			exitPoint = "Castle Entry";
			thePlayer.startPoint = exitPoint;
			break;
		
		case "worldmap":
			SceneManager.LoadScene ("worldmap");
			exitPoint = "World Map Entry";
			thePlayer.startPoint = exitPoint;
			break;

		case "CastleDungeon":
			SceneManager.LoadScene ("CastleDungeon");
			exitPoint = "Castle Dungeon In";
			thePlayer.startPoint = exitPoint;
			musicController.SwitchTrack (1);
			break;
		
		}
	}

}
