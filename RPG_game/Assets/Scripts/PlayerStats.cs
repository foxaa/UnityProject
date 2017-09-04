using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;

    public int[] expToLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;
    public int currentHP;
    public int currentAttack;
    public int currentDefence;

	public GameObject levelUp;
	public GameObject expNumbers;

    private PlayerHealthManager thePlayerHealth;
	// Use this for initialization
	void Start () {
        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

	
	}
	
	// Update is called once per frame
	void Update () {
        if(currentExp >= expToLevelUp[currentLevel])
        {
           // currentLevel++;
            LevelUp();

        }
	
	}

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
		var clone = (GameObject)Instantiate (expNumbers, thePlayerHealth.transform.position, Quaternion.Euler (Vector3.zero)); //pretvara taj instancirani objekt u gameobject sa (GameObject) i sprema se u var clone varijablu
		clone.GetComponent<FloatingExpNumber> ().expNumber = expToAdd;
    }
    public void LevelUp()
    {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];//uvecavanje trenutnog hp-a za razliku hpa ovog levela i proslog

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
		if(currentLevel >1)
		{
		var clone = (GameObject) Instantiate(levelUp, thePlayerHealth.transform.position, Quaternion.Euler(Vector3.zero)); //pretvara taj instancirani objekt u gameobject sa (GameObject) i sprema se u var clone varijablu
		}
    }
}
