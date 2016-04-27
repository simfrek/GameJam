using UnityEngine;
using System.Collections;

public class toggleMap : MonoBehaviour {
	public GameObject cameraMap;
	public GameObject Player2;
	public GameObject Player2Camera;
	public GameObject Player1;
	private ScientistController P1Controller;
	private EngineerController P2Controller;
	private int time = 0;
	public bool twoControllers;
	// Use this for initialization
	void Start () {
		isTwoControllers ();
		P1Controller = Player1.GetComponent <ScientistController> ();
		P2Controller = Player2.GetComponent <EngineerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		isTwoControllers ();
		if (Input.GetAxisRaw ("R-Trigger") < -0.9 && time <= 0) {
			time = 60;
			cameraMap.camera.enabled = !cameraMap.camera.enabled;
			if (!isTwoControllers ()) {
				if (Player2Camera.camera.depth == 0) {
					camera.depth = 0;
					Player2Camera.camera.depth = 1;
					P1Controller.enabled = false;
					P2Controller.enabled = true;
				} else {
					camera.depth = 1;
					Player2Camera.camera.depth = 0;
					P1Controller.enabled = true;
					P2Controller.enabled = false;
				}
			}
		} else
		if (time > 0)
			time --;
	}

	bool isTwoControllers()
	{
		int i = 0;
		int j = 0;
		while (i < 10) {
			try
			{
				if (Input.GetJoystickNames()[i] == "Controller (XBOX 360 For Windows)" || Input.GetJoystickNames()[i] == "XBOX 360 For Windows (Controller)"){
					Debug.Log("Controller " + i + " exists");
					j++;
				}
				i++;
			}
			catch{i++;}
		}
		if (j >= 2)
			twoControllers = true;
		else
			twoControllers = false;
		if (twoControllers == true) {
			camera.rect = new Rect(0.5f,0,0.5f,1);
			Player2Camera.camera.rect = new Rect(0,0,0.5f,1);
		} else {
			camera.rect = new Rect(0,0,1,1);
			Player2Camera.camera.rect = new Rect(0,0,1,1);
			Debug.Log("HERE");
		}
		return twoControllers;
	}
}
