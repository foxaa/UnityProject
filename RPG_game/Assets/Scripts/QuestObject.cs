using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {

    public QuestManager questManager;
    public int questNumber;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(isItemQuest)
        {
            if(questManager.itemCollected==targetItem)
            {
                questManager.itemCollected = null;
                EndQuest();
            }
        }

        if(isEnemyQuest)
        {
            if(questManager.enemyKilled==targetEnemy)
            {
                questManager.enemyKilled = null;
                enemyKillCount++;
            }
            if(enemyKillCount==enemiesToKill)
            {
                EndQuest();
            }
        }
	
	}
    public void StartQuest()
    {
        questManager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        questManager.ShowQuestText(endText);
        questManager.questCompleted[questNumber]=true;
        gameObject.SetActive(false);
    }
}
