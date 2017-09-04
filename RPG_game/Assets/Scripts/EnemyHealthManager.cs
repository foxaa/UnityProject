using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;

    public static int enemyCounter = 0;

    private PlayerStats thePlayerStats;

	private MoneyManager moneyManager;
	//private int moneyToGive;

	public GameObject goldDrop;
	//private Vector3 goldPosition=new Vector3(transform.position.x,transform.position.y,-1.5f);

	private ItemDroping itemDroping;
	private int chanceToDropItem;

    public int enemyExp;

    public string enemyQuestName;
    private QuestManager questManager;
    //public int enemyCounter = 0;

    // Use this for initialization
    void Start()
    {
		//moneyToGive = Random.Range (3, 20);
		chanceToDropItem = Random.Range(1,10);
		//Debug.Log ("RANDOM:" + moneyToGive);
        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStats>();//bez ovog object reference not set to an instance of object
        questManager = FindObjectOfType<QuestManager>();
		moneyManager = FindObjectOfType<MoneyManager> ();
		itemDroping = GetComponent<ItemDroping> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            questManager.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            enemyCounter = enemyCounter + 1;
            thePlayerStats.AddExp(enemyExp);
			//moneyManager.AddMoney (moneyToGive);
			itemDroping.DropItem (chanceToDropItem);
			Instantiate (goldDrop,new Vector3(transform.position.x,transform.position.y,transform.position.z-1.5f),transform.rotation);
            
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
       
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
