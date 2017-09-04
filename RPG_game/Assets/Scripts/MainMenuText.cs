using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour {

	public Text text;

	public Text Previous;
	public Text Next;

	enum States { first, second }

	States myState;

	// Use this for initialization
	void Start () 
	{
		myState = States.first;
	}

	// Update is called once per frame
	void Update () 
	{
		if (myState == States.first) first();
		else if (myState == States.second) second();

	}

	// PRE-GAME
	void first()
	{
		/*text.text = "VRIJEME RADNJE : 2016. godina\n\n" +
			"MJESTO RADNJE : Ul. kneza Trpimira 2B, 31000, Osijek \n\n" +
			"TEMA : Skup studentskog zbora. Problem prehrane u studentskim kantinama" +
			"\n\nRADNJA: Govor Izv.prof.dr.sc Prodo Ekana, prodekana za nastavu i studente\n";*/

		text.text = "You are a young prince of a peaceful kingdom. It's been like this for a long time.\n\n" +
		"But something is lurking in the dark corners of the kingdom.\n\n";


		if (Input.GetKeyDown("d")) myState = States.second;

		Previous.enabled = false;
		Next.enabled = true;
	}
	void second()
	{
		text.text = "There have been rumours about monsters roaming around old mines and dungeons.\n\n"+
			"People are getting scared and someone should find out what it's all about. Is it only rumours or is there really something\n" +
			"that will try to destroy your kingdom.\n\n";


		if (Input.GetKeyDown("a")) myState = States.first;

		Previous.enabled = true;
		Next.enabled = false;
	}
}
