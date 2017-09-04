using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	//private CameraController theCamera;
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene (name);
		//theCamera = FindObjectOfType<CameraController> ();
		//theCamera.gameObject.SetActive (true);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
