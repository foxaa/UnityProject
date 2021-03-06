﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    private static bool UIExists;

    private PlayerStats thePS;
    public Text levelText;
	public Text xpText;


	// Use this for initialization
	void Start () {

        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePS = GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {

        healthBar.maxValue = playerHealth.playerMaxHealth;

        healthBar.value = playerHealth.playerCurrentHealth;

        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

        levelText.text = "Lvl: " + thePS.currentLevel;

		xpText.text = "XP: " + thePS.currentExp + "/" + thePS.expToLevelUp [thePS.currentLevel];
         
	
	}
}
