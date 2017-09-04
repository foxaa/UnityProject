using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownPortal : MonoBehaviour {

	public GameObject townPortal;
	public Texture texture;
	private PlayerController thePlayer;
	public bool usedPortal;
	public Rect rect=new Rect(0,0,0,0);

	// Use this for initialization
	void Start () {
	
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea (rect);
		GUILayout.BeginHorizontal ();

		if (GUILayout.Button (texture, GUILayout.Width (50), GUILayout.Height (50))) {
			Instantiate (townPortal, new Vector3(thePlayer.transform.position.x+2f,thePlayer.transform.position.y,thePlayer.transform.position.z), thePlayer.transform.rotation);
			usedPortal = true;
		}

		GUILayout.EndArea ();
		GUILayout.EndHorizontal ();
	}
}
