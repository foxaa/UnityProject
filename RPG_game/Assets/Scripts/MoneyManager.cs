using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public int currentMoney = 0;
	public Text moneyText;

	// Use this for initialization
	/*void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
	public void SpendMoney(int moneyToSpend)
	{
		currentMoney -= moneyToSpend;
		moneyText.text = "Gold: " + currentMoney;
	}

	public void AddMoney(int moneyToAdd)
	{
		currentMoney += moneyToAdd;
		moneyText.text = "Gold: " + currentMoney;
	}
}
