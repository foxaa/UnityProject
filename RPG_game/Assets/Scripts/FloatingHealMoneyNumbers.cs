using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingHealMoneyNumbers : MonoBehaviour {

	public float moveSpeed;
	public int heal_or_money_number;
	public Text displayNumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		displayNumber.text = "+" + heal_or_money_number;
		transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);

	}
}
