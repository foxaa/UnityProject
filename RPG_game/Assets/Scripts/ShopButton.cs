using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

	//public List<CollectableRef> items=null;
	private MoneyManager moneyManager;
	private Inventory inventory;
	public Collectable[] items = new Collectable[5];
	public int number;

	public Text name;
	public Text cost;
	public Text description;

	public AudioSource source;

	// Use this for initialization
	void Start () {
		moneyManager = FindObjectOfType<MoneyManager> ();
		inventory = FindObjectOfType<Inventory> ();
		SetButton ();
	}
	
	public void SetButton()
	{
		//string costString = items [number].cost.ToString();
		name.text = items [number].name;
		cost.text = "$"+ items[number].cost;
		description.text = items [number].description;

	}

	public void OnClick()
	{
		Debug.Log ("clicked");
		if (moneyManager.currentMoney >= items[number].cost) {
			Debug.Log ("uso");
			moneyManager.SpendMoney (items[number].cost);
			inventory.AddItem (items [number]);
			source.Play ();
		}
	}
}
