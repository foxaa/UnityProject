using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TownPortalUsage : MonoBehaviour {

	public string exitPoint;
	private PlayerController thePlayer;
	public GameObject homePortal;
	private TownPortal Portal;
	public string sceneName;
	public GameObject point;
	private MusicController musicController;
	// Use this for initialization

	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		Portal = FindObjectOfType<TownPortal> ();
		musicController = FindObjectOfType<MusicController> ();
		DontDestroyOnLoad (this);
		//sceneName = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			Scene scene=SceneManager.GetActiveScene ();
			Debug.Log ("name:" + scene.name);
			SceneManager.LoadScene ("main");
			sceneName = SceneManager.GetActiveScene ().name;
			thePlayer.startPoint = exitPoint;
			thePlayer.enteredPortal = true;
			musicController.SwitchTrack (0);
			//townPortal.SetActive (true);
			CreateMirrorPortal();
		}
	}

	public void CreateMirrorPortal()
	{
		/*if (thePlayer.enteredPortal == true) {
			townPortal.SetActive (true);
		} else if (thePlayer.enteredPortal == false) {
			townPortal.SetActive (false);
		}*/
		Instantiate (homePortal, new Vector3 (point.transform.position.x, point.transform.position.y, point.transform.position.z), thePlayer.transform.rotation);
		//DontDestroyOnLoad (homePortal);
		Destroy (this.gameObject);//da se unisti ovaj prvi portal instancirani nakon pritiska tipke
	}
}
