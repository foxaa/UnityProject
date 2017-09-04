using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	private Inventory inventory;
	private bool pickedup=false;
	public Collectable obj = null;
	public string name = null;
	public int cost;
	public string description;
	public CollectableRef collRef;
	//public int damageToGive;
	void Start(){
		inventory = FindObjectOfType<Inventory> ();
		//DontDestroyOnLoad (gameObject.transform);

	}
	public enum ItemType
	{
		Item,
		Weapon
	};

	public ItemType itemtype;
	public Texture itemLogo=null;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			if(pickedup==false){
				Debug.Log ("dodavanje");
				inventory.AddItem (this);
				Debug.Log ("dodan");
				Destroy (gameObject);
			//gameObject.SetActive(false);
		
			//other.gameObject.SetActive(false);
			//Debug.Log ("obrisan");
			}
			pickedup = true;

		}
	}
}
