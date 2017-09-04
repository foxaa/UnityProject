using UnityEngine;
using System.Collections;

public class MusicSwitch : MonoBehaviour {

	private MusicController musicController;
	public int trackNumber;

	// Use this for initialization
	void Start () {
		musicController = FindObjectOfType<MusicController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			musicController.SwitchTrack (trackNumber);
		}
	}
}
