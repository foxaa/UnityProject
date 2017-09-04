using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    //private PlayerHealthManager hp;
    private int currentDamage;
    public int damageToGive;
    public GameObject damageNumber;
    private PlayerStats playerStats;
    
	// Use this for initialization
	void Start () {
        playerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
			Debug.Log ("player udaren");
            currentDamage = damageToGive - playerStats.currentDefence;
            if(currentDamage<0)
            {
                currentDamage = 0;
            }
            //hp = FindObjectOfType<PlayerHealthManager>();
            //hp.HurtPlayer(damageToGive);
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false); //deaktiviramo playera i pocinje ucitavanje levela nanovo u trajanju odredenom varijablom waitToReload
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);

            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero)); //pretvara taj instancirani objekt u gameobject sa (GameObject) i sprema se u var clone varijablu
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            //PlayerController.printaj();

        }
    }
}
