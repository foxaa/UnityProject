using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {

	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	public float chaseRange;
	private PlayerController playerController;
	public LayerMask playerLayer;
	public bool playerInRange;

	//public float chaseRange;
	//private PlayerController playerController;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		playerController = FindObjectOfType<PlayerController> ();

		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

	}

	// Update is called once per frame
	void Update () {

		if(moving)
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if(timeToMoveCounter < 0f)
			{
				moving = false;
				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

			}

		}
		else
		{
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if(timeBetweenMoveCounter < 0f)
			{
				moving = true;
				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
			}
		}
		if(reloading)
		{
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//ponovno ucitavanje aktivne scene te aktivacija playera
				thePlayer.SetActive(true);

			}
		}

		playerInRange = Physics2D.OverlapCircle(transform.position, chaseRange, playerLayer);
		if (playerInRange == true) {
			transform.position = Vector3.MoveTowards (transform.position, playerController.transform.position, (moveSpeed*0.5f) * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		/*if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false); //deaktiviramo playera i pocinje ucitavanje levela nanovo u trajanju odredenom varijablom waitToReload
            reloading = true;
            thePlayer = other.gameObject;

        }*/
	}

	void OnDrawGizmosSelected(){

		Gizmos.DrawSphere (transform.position, chaseRange);
	}
}
