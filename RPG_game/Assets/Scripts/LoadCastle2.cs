using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadCastle2 : MonoBehaviour {

	public string exitPoint;
	private PlayerController thePlayer;
	public string LevelToLoad;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player" && thePlayer.finishedFirstDungeon == true) {
			SceneManager.LoadScene ("castle_2");
			thePlayer.startPoint = exitPoint;
			Debug.Log (exitPoint);
		} else {
			SceneManager.LoadScene(LevelToLoad);
			thePlayer.startPoint = exitPoint;
			Debug.Log (exitPoint);
		}
	}
}
