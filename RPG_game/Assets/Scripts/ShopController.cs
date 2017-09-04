using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour {

	public GameObject shopPanel;

	/*void Start() {
		DontDestroyOnLoad (transform.gameObject);
	}*/

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			Debug.Log ("sudar");
			openShop ();
		}
	}

	public void openShop()
	{
		shopPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void closeShop()
	{
		shopPanel.SetActive (false);
		Time.timeScale = 1;
	}
}
