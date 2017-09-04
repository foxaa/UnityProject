using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingExpNumber : MonoBehaviour {

	public float moveSpeed;
	public int expNumber;
	public Text displayNumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		displayNumber.text = "+ " + expNumber+" XP";
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);

	}
}
