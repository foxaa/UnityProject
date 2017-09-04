using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDroping : MonoBehaviour {

	public List<CollectableRef> items=null;
	private int itemToDrop;

	public void DropItem(int chanceToDrop)
	{
		if (chanceToDrop == 1) {
			for (int i = 0; i < items.Count; i++) {
				itemToDrop = Random.Range (0, items.Count);
				Instantiate(items[itemToDrop].objectPrefab, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z),Quaternion.identity);
				items.RemoveAt(itemToDrop);
			}
		}
	}
}
