using UnityEngine;
using System.Collections;

public class WeaponChange : MonoBehaviour {

    //private EnemyHealthManager counter;

	// Use this for initialization
	void Start () {

       
       //counter = FindObjectOfType<EnemyHealthManager>();

	}

    // Update is called once per frame
    void Update() {

        if (EnemyHealthManager.enemyCounter >= 2)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
	}

}
