using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	private EnemyHealthManager enemyHealth;
	private HurtPlayer hurtPlayer;
	public GameObject projectile;

	public float waitBetweenShots;
	private float shotCounter;

	// Use this for initialization
	void Start () {

		shotCounter = waitBetweenShots;
		enemyHealth = GetComponent<EnemyHealthManager> ();
		hurtPlayer = GetComponent<HurtPlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		shotCounter -= Time.deltaTime;
		if (enemyHealth.CurrentHealth == enemyHealth.MaxHealth) {
			StartCoroutine ("Boss");
		}
		
	
	}

	IEnumerator Boss()
	{
		while (true) {
			while (enemyHealth.CurrentHealth >= enemyHealth.MaxHealth * 0.8f) {
				hurtPlayer.damageToGive = 10;
				yield return new WaitForSeconds (1f);
			}
				int i = 0;
			//if (shotCounter < 0) {
			while (i < 5 && shotCounter < 0) {
					Instantiate (projectile, this.transform.position, Quaternion.identity);
					shotCounter = waitBetweenShots;
					yield return new WaitForSeconds (1f);
					i++;
					Debug.Log (i);
				}
			//}
			while (enemyHealth.CurrentHealth <= enemyHealth.MaxHealth * 0.8f) {
				hurtPlayer.damageToGive = 10;
				yield return new WaitForSeconds (1f);
			}
				//hurtPlayer.damageToGive = 20;
		}
	}

}
