using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

	private Inventory inventory;
    private PlayerStats playerStats;

    
	// Use this for initialization
	void Start () {
        playerStats = FindObjectOfType<PlayerStats>();
		inventory = FindObjectOfType<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Enemy") {
			Debug.Log ("enemy udaren");
			if (inventory.currentObject != null) {
				currentDamage = damageToGive + playerStats.currentAttack + inventory.currentObject.damage;
			} else
				currentDamage = damageToGive + playerStats.currentAttack;
			//Destroy(other.gameObject);
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (currentDamage);
			Instantiate (damageBurst, hitPoint.position, hitPoint.rotation);

			var clone = (GameObject)Instantiate (damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero)); //pretvara taj instancirani objekt u gameobject sa (GameObject) i sprema se u var clone varijablu
			clone.GetComponent<FloatingNumbers> ().damageNumber = currentDamage;
		} else if (other.gameObject.tag == "Chest") {
			Debug.Log ("chest");
			other.gameObject.GetComponent<TreaseureChest> ().DropItem ();

		}
    }
}
