using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	private PlayerController playerController;
	// Use this for initialization
	void Start () {
	
		playerController = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerController.finishedFirstDungeon) {
			this.gameObject.SetActive (true);
		}
	
	}
}
