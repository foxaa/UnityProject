using UnityEngine;
using System.Collections;

public class QuestTrigger : MonoBehaviour {

    private QuestManager questManager;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;
   
	// Use this for initialization
	void Start () {
        questManager = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name=="Player")
        {
            if(!questManager.questCompleted[questNumber])//provjera da nije quest zavrsen
            {
                if(startQuest==true && !questManager.quests[questNumber].gameObject.activeSelf)//provjera je li triger za pocetak quest i dali je quest inactive
                                                                                                //da se moze aktivirat
                {
                    questManager.quests[questNumber].gameObject.SetActive(true);
                    questManager.quests[questNumber].StartQuest();
                }

                if(endQuest==true && questManager.quests[questNumber].gameObject.activeSelf)//provjera da li je trigger za kraj questa
                {                                                                           //i da li je quest aktiviran da se moze zavrsit
                   
                    questManager.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
