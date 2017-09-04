using UnityEngine;
using System.Collections;

public class TreaseureChest : MonoBehaviour {

	private ItemDroping itemDrop;
	private int chanceToDropItem=1;
	public GameObject destroyEffect;
	// Use this for initialization

	void Start () {
		
		itemDrop = GetComponent<ItemDroping> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DropItem()
	{
		Destroy (gameObject);
		Instantiate (destroyEffect, gameObject.transform.position, gameObject.transform.rotation);
		itemDrop.DropItem (chanceToDropItem);

	}
}
