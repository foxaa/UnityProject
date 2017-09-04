using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    //public float diagonalMoveModifier;

    private Animator anim;

    private bool playerMoving;

    public Vector2 lastMove;
    private Vector2 moveInput;

    private Rigidbody2D myRigidbody;

    private static bool playerExists; //static varijabli se moze pristupi pomocu klasa.varijabla, static varijabla se koristi u svim instancama klase
                                      // sve sto ima skriput PlayerController imat ce zajednicu static varijablu playerExists

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;

    public string startPoint;

    public bool canMove;

	private Inventory inventory;

	//public AudioClip[] walkSounds;
	public AudioClip walkSound;
	public AudioClip swordSound;

	public AudioSource source;

	public GameObject talkCloud;
	public bool talkAble;

	public bool enteredPortal=false;
	//private bool soundPlaying;
    
    //public static int a = 10;
	public bool finishedFirstDungeon;
	public bool talkedWithKing=false;

	public int dungeonCounter;

	void Start () {
		inventory = FindObjectOfType<Inventory> ();

        anim = GetComponent<Animator>(); // pristup animatoru koji se nalazi na istom objektu kao i ova skripta PlayerController

        myRigidbody = GetComponent<Rigidbody2D>();

        if(!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;

        lastMove = new Vector2(0, -1f);//da mac nepocne na startu na sredini igraca(spritea)
	
	}

    void Update() {
        playerMoving = false;

        if(canMove==false)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        if (!attacking)
        {

            /*if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,0f,0f));

                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0); //dobije vrijednost za kretanje po x-osi
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }
            */
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            if(moveInput!=Vector2.zero)
            {
				PlayWalkSound ();
				//GetComponent<AudioSource> ().Play ();
				//source.clip=walkSounds[Random.Range(0,walkSounds.Length)];
				//source.PlayOneShot (walkSounds, 0.9f);
				//source.PlayOneShot(walkSounds[Random.Range(0,walkSounds.Length)]);
                myRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }else
            {
                myRigidbody.velocity = Vector2.zero;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
				if (inventory.inventory != null) {
					if (inventory.equiped == true) {
						attackTimeCounter = attackTime;
						attacking = true;

						myRigidbody.velocity = Vector2.zero;//da se nemoze igrac kretat dok napada
						anim.SetBool ("Attack", true);
						source.PlayOneShot (swordSound, 0.1f);
					}
				}
            }
            /*if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                currentMoveSpeed = moveSpeed * diagonalMoveModifier;
            }else
            {
                currentMoveSpeed = moveSpeed;
            }*/

        } //ako nenapadamo
		if(Input.GetKeyDown(KeyCode.F1))
			{
				inventory.DestroyItem(0);
			}

		if(Input.GetKeyDown(KeyCode.F2))
		{
			inventory.DestroyItem(1);
		}
		if(Input.GetKeyDown(KeyCode.F3))
		{
			inventory.DestroyItem(2);
		}
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        anim.SetBool("PlayerMoving", playerMoving);

        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
	
	}

    /*public static void printaj()
    {
        a = a * 2;
        Debug.Log("asd");
        Debug.Log(a);
    }*/

	/*void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Collectable")
		{
			Debug.Log ("dodavanje");
			inventory.AddItem (other.gameObject);
			Debug.Log ("dodan");
			Destroy (other.gameObject);
			//other.gameObject.SetActive(false);
			//Debug.Log ("obrisan");

		}
	}*/

	public void PlayWalkSound()
	{
		
		source.clip = walkSound;
		source.pitch = Random.Range (0.5f, 0.7f);
		if (!source.isPlaying) {
			source.PlayOneShot (walkSound,0.15f);
		}
			/*for (int i = 0; i < walkSounds.Length; i++) {
			Debug.Log ("IME:"+walkSounds.ToString);
				source.clip = walkSounds [Random.Range (0, walkSounds.Length)];
				source.PlayOneShot (walkSounds [i], 0.2f);
			}*/
		/*source.clip=walkSounds[Random.Range(0,walkSounds.Length)];
		if (!source.isPlaying) {
			source.Play ();
		}*/
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "FirstDungeonClear") {
			finishedFirstDungeon = true;
			Debug.Log ("Finished");
		}

		if (other.gameObject.tag == "DungeonLevel") {
			dungeonCounter++;
			Debug.Log ("Dungeon Counter:" + dungeonCounter);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "NPC") {
			talkAble = true;
			Talk ();
		}
		if (other.gameObject.name == "King") {
			talkAble = true;
			Talk ();
			talkedWithKing = true;
		}
	}
	void OnCollisionExit2D(Collision2D other)
	{
		talkAble = false;
		Talk ();
	}
		

	public void Talk()
	{
		if (talkAble) {
			talkCloud.SetActive (true);
		} else if (talkAble == false) {
			talkCloud.SetActive (false);
		}
	}

	/*IEnumerator conversationCloud()
	{
		talkCloud.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		Debug.Log ("Poslije wait");
		talkCloud.SetActive (false);
	}*/
}
