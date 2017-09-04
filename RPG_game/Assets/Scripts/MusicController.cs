using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public static bool musicExists;
	public AudioSource[] tracks;
	public int currentTrack;
	public bool musicCanPlay;
	// Use this for initialization
	void Start () {

		if(!musicExists)
		{
			musicExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (musicCanPlay) {
			if (!tracks [currentTrack].isPlaying) {
				tracks [currentTrack].Play ();
			}
		} 
		else {
			tracks [currentTrack].Stop ();
		}
	}

	public void SwitchTrack(int newTrack)
	{
		tracks [currentTrack].Stop ();
		currentTrack = newTrack;
		tracks [currentTrack].Play ();
	}
}
