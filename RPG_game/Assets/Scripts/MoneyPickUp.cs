using UnityEngine;
using System.Collections;

public class MoneyPickUp : MonoBehaviour {

	private int moneyToGive;
	private MoneyManager moneyManager;
	public GameObject MoneyPickedUp;
	public GameObject moneyNumber;
	// Use this for initialization
	void Start () {
		moneyManager = FindObjectOfType<MoneyManager> ();
		moneyToGive = Random.Range (3, 20);
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			moneyManager.AddMoney (moneyToGive);
			Destroy (gameObject);
			Instantiate (MoneyPickedUp, transform.position, transform.rotation);
			var clone = (GameObject)Instantiate(moneyNumber, other.transform.position, Quaternion.Euler(Vector3.zero)); 
			clone.GetComponent<FloatingHealMoneyNumbers>().heal_or_money_number = moneyToGive;
		}
	}
}
