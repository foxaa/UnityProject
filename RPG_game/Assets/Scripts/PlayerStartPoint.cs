using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {


    private PlayerController thePlayer;
    private CameraController theCamera;
    

    public Vector2 startDirection;

    public string pointName;

	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            //thePlayer.lastMove = startDirection; //koristimo varijablu iz klase PlayerController

            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
			Debug.Log ("Kordinate kamere y-os:" + theCamera.transform.position.y);
			Debug.Log ("Kordinate kamere x-os:" + theCamera.transform.position.x);

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
