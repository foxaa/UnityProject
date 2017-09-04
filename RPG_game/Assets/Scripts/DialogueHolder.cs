using UnityEngine;
using System.Collections;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dialogueManager;

    public string[] dialogueLines;

	// Use this for initialization
	void Start () {
        dialogueManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)//umjesto Enter ide Stay 
    {
        if(other.gameObject.name=="Player")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                //dialogueManager.ShowBox(dialogue);
                if(dialogueManager.dialogueActive==false)
                {
                    dialogueManager.dialogueLines = dialogueLines;
                    dialogueManager.currentLine = 0;
                    dialogueManager.ShowDialogue();
                }

                if(transform.parent.GetComponent<VillagerMovement>() != null)//parent od objekta koji ima ovu skriptu sto je NPC i na njemu ako ima skripta vilager movement
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
