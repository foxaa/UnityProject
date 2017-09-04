using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string LevelToLoad;

    public string exitPoint;

    private PlayerController player;

	private CameraController theCamera;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
		theCamera = FindObjectOfType<CameraController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
			//StartCoroutine ("Fade");
           SceneManager.LoadScene(LevelToLoad);
           player.startPoint = exitPoint;
		   Debug.Log (exitPoint);

        }
    }

	IEnumerator Fade()
	{
		float fadeTime = theCamera.GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene(LevelToLoad);
		player.startPoint = exitPoint;
		Debug.Log (exitPoint);
	}
}
