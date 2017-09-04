using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadDungeon : MonoBehaviour {

	public string exitPoint;
	private PlayerController thePlayer;
	public string LevelToLoad;
	public bool GUItoggle=false;
	private MusicController musicController;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		musicController = FindObjectOfType<MusicController> ();
	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" & thePlayer.talkedWithKing == true) {
			Debug.Log ("prvi if");
			SceneManager.LoadScene ("dungeon");
			thePlayer.startPoint = exitPoint;
			Debug.Log (exitPoint);
			GUItoggle = false;
			musicController.SwitchTrack (1);
		} else if(other.gameObject.name=="Player" & thePlayer.talkedWithKing==false) {
			thePlayer.talkedWithKing = false;
			GUItoggle = true;
			Debug.Log ("nista");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		GUItoggle =false;
	}

	void OnGUI()
	{
		if (GUItoggle==true) {
			GUI.contentColor = Color.black;
			GUI.Label(new Rect(Screen.width*0.5f, Screen.height*0.5f, 1000f, 50f), "You have to talk to the king first."); 
		}
	}
}
