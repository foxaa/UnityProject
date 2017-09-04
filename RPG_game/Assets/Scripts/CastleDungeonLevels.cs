using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CastleDungeonLevels : MonoBehaviour {

	//public string LevelToLoad;

	public string exitPoint="Castle Dungeon In";
	private MusicController musicController;

	private PlayerController player;

	public int numberOfLevels = 0;
	public int maxNumOfLevels;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		musicController = FindObjectOfType<MusicController> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" & player.dungeonCounter <= maxNumOfLevels) {
			SceneManager.LoadScene ("CastleDungeon");
			player.startPoint = exitPoint;
			Debug.Log (exitPoint);
			numberOfLevels++;
			Debug.Log ("NUMBER::" + numberOfLevels);
		} else if (other.gameObject.name == "Player" & player.dungeonCounter > maxNumOfLevels) {
			SceneManager.LoadScene ("main");
			player.startPoint = "Village Entry";
			musicController.SwitchTrack (0);
		}
	}
}
