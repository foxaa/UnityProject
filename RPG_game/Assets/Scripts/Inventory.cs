using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	//public List<GameObject> inventory=new List<GameObject>();

	public List<CollectableRef> inventory = null;
	public Collectable[] items = new Collectable[5];
	public Texture[] texture = new Texture[5];
	public string[] names= new string[100];

	private string tempString = null;
	private Texture temp=null;
	private Collectable tempGO = null;
	//public GameObject currentObject=null;
	//public GameObject currObj = null;
	public CollectableRef currentObject=null;
	public GameObject currObj=null;

	public GameObject pickedupItem = null;



	public Rect rect=new Rect(0,0,0,0);
	public static bool inventoryExists;

	public bool deleted=false;
	private bool used=false;
	public bool equiped=false;

	private PlayerController thePlayer;
	private PlayerHealthManager playerHealthManager;

	public GameObject healEffect;
	public GameObject healNumber;

	public AudioSource source;


	void Start(){
		//Instantiate (inventory [0], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		//DontDestroyOnLoad(gameObject.transform);
		/*if (!inventoryExists) {
			inventoryExists = true;
			DontDestroyOnLoad (gameObject.transform);
		} else {
			Destroy (gameObject);
		}*/
		thePlayer = FindObjectOfType<PlayerController> ();
		playerHealthManager = FindObjectOfType<PlayerHealthManager> ();

	}
	public void ChangeItem(CollectableRef newObject)
	{
		if (currObj!= null) {
			Destroy (currObj);
			Debug.Log ("Delete item");
		}
		currObj=GameObject.Instantiate(newObject.objectPrefab,new Vector3 (thePlayer.transform.GetChild(0).transform.position.x, thePlayer.transform.GetChild(0).transform.position.y, thePlayer.transform.GetChild(0).transform.position.z), thePlayer.transform.GetChild(0).transform.rotation) as GameObject;
		currObj.transform.parent = thePlayer.transform.GetChild (0);
		equiped = true;

	}

	public void AddItem(Collectable newItem)
	{
		source.Play ();
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i] == null) {
				inventory.Insert(i,newItem.collRef);
				return;
			}
		}
		/*tempString = newItem.name;
		//pickedupItem = newItem;
		temp=newItem.itemLogo;
		//pickedupItem=Collectable.Instantiate(newItem.gameObject,new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Collectable;
		for (int i = 0; i < texture.Length; i++) {
				if (texture [i] == null) {
					texture [i] = temp;
					names [i] = tempString;
					return;
				}
		}*/

		//Destroy (newItem);
	}
	public void DestroyItem(int index)
	{
		//currObj.transform.parent = null;
		//currObj.transform.position = new Vector3 (transform.position.x + Random.Range(2,5), transform.position.y+Random.Range(2,5), transform.position.z);
		//currObj = null;
		//Debug.Log("INVENTORY COUNT:"+inventory.Count);
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i]!=null) {
				//if (inventory [i] == currentObject) {
					if (inventory.IndexOf (inventory [i]) == index) {
					if (inventory [i] == currentObject) {
						return;
					} else {
						//currObj.transform.parent = null;
						//currObj.transform.position = new Vector3 (transform.position.x + Random.Range (2, 5), transform.position.y + Random.Range (2, 5), transform.position.z);
						//currObj = null;
						//Destroy(currObj);
						Instantiate (inventory [i].objectPrefab, new Vector3 (transform.position.x + Random.Range (-2,2), transform.position.y + Random.Range (-2, 2), transform.position.z), Quaternion.identity);
						inventory.RemoveAt (index);
					}
					}
				//}
			}
		}
		//inventory.RemoveAt (index);

	}
	public void DestroyItemAfterUsage(CollectableRef collRef)
	{
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory [i] == collRef) {
				inventory.Remove (collRef);
				return;
			}
		}	
	}
	public void UseItem(CollectableRef collRef)
	{
		Debug.Log ("use item function");
		for (int i = 0; i < inventory.Count; i++) {
			if (collRef.name == "HP_potion_ref" || collRef.name=="HP_potion_50_ref") {
				if (playerHealthManager.playerCurrentHealth < playerHealthManager.playerMaxHealth) {
					playerHealthManager.playerCurrentHealth += collRef.healPoints;
					Instantiate (healEffect, thePlayer.transform.position, thePlayer.transform.rotation);
					var clone = (GameObject)Instantiate(healNumber, thePlayer.transform.position, Quaternion.Euler(Vector3.zero)); 
					clone.GetComponent<FloatingHealMoneyNumbers>().heal_or_money_number = collRef.healPoints;
					//DestroyItemAfterUsage (collRef);
					used = true;
					if (playerHealthManager.playerCurrentHealth > playerHealthManager.playerMaxHealth) {
						playerHealthManager.playerCurrentHealth = playerHealthManager.playerMaxHealth;
					}
					return;
				} else {
					used = false;
					return;
				}
			}
		}
	}
	/*public void AddItem(Collectable newItem)
	{
		//pickedupItem = newItem;
		temp=newItem.itemLogo;
		//pickedupItem=Collectable.Instantiate(newItem.gameObject,new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as Collectable;
		for (int i = 0; i < texture.Length; i++)
		{
			if (texture[i] == null)
			{
				texture [i] = temp;
				return;
			}
		}
		//Destroy (newItem);
	}*/

	void OnGUI()
	{
		GUILayout.BeginArea (rect);
		GUILayout.BeginHorizontal ();

		foreach (CollectableRef collectableref in inventory) {
			if (collectableref != null) {
				if (GUILayout.Button (collectableref.objectImage, GUILayout.Width (50), GUILayout.Height (50))) {
					//Instantiate (inventory[0], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					if (collectableref.names == "potion") {
						UseItem (collectableref);
						if (used == true) {
							for (int i = 0; i < inventory.Count; i++) {
								if (inventory [i] == collectableref) {
									DestroyItemAfterUsage (collectableref);
									return;
								}
							}
						}
					} else {
						currentObject = collectableref;
						//currentObject.damage = collectableref.damage;
						ChangeItem (collectableref);
						//Object.Instantiate(collectableref.objectPrefab,transform.position,Quaternion.identity);
						Debug.Log ("Trenutni: " + currentObject);
					}
				}
			}
				//if (GUILayout.Button ("del", GUILayout.Width (10), GUILayout.Height (10))) {
				//	DestroyItem (collectableref);
				//}
						//Destroy (currentObject);
						//GameObject.Instantiate(currentObject,new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					}
				
		GUILayout.EndArea();
		GUILayout.EndHorizontal();
	}


	/*void OnGUI()
	{
		GUILayout.BeginArea (rect);
		GUILayout.BeginVertical ();

		foreach (Texture text in texture) {
			if (text != null) {
				foreach (string x in names) {
					if (GUILayout.Button (new GUIContent(x,text), GUILayout.Width (50), GUILayout.Height (50))) {
						//Instantiate (Resources.Load (x) as GameObject,transform.position,transform.rotation);
						//Instantiate (inventory[0], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
						//currentObject = collectable;
						ChangeItem (Resources.Load (x) as GameObject);
						Debug.Log ("Trenutni: " + currentObject);
						//Destroy (currentObject);
						//GameObject.Instantiate(currentObject,new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					}
				}
			}
		}
		GUILayout.EndArea();
		GUILayout.EndVertical();
	}*/
}
