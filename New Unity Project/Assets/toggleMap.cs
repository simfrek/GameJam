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
	// Use this for initialization
	void Start () {
		P1Controller = Player1.GetComponent <ScientistController> ();
		P2Controller = Player2.GetComponent <EngineerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("triggers") < -0.2 && time <= 0) {
			time = 30;
			cameraMap.camera.enabled = !cameraMap.camera.enabled;
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
		} else
			if (time >0)
			time --;
	}
}
