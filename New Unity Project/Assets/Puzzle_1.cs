using UnityEngine;
using System.Collections;

public class Puzzle_1 : MonoBehaviour {
	
	private GameObject Scientist;
	private GameObject Engineer;
	private GameObject Player;
	public GameObject door;
	public GameObject Plate1;
	public GameObject Plate2;
	public GameObject Plate3;
	public GameObject Plate4;
	public GameObject Plate5;
	public GameObject Plate6;
	public bool PlateOn1;
	public bool PlateOn2;
	public bool PlateOn3;
	public bool PlateOn4;
	public bool PlateOn5;
	public bool PlateOn6;
	public int key = 47;
	public int code = 0;
	public int distance = 6;
	private int range = 1;
	private Vector3 open;
	// Use this for initialization
	void Start () {
		Scientist = GameObject.FindGameObjectWithTag ("Scientist");
		Engineer = GameObject.FindGameObjectWithTag ("Engineer");
		Player = GameObject.FindGameObjectWithTag ("Player");
		open = new Vector3 (door.transform.position.x - distance, door.transform.position.y, door.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (code == key)
			door.transform.position = open;
		
		if (isOn (Scientist, Plate1) || isOn (Engineer, Plate1)){
			if (PlateOn1) {
				PlateOn1 = !PlateOn1;
				code -= 1;
			}
			else{
				PlateOn1 = !PlateOn1;
				code += 1;
			}			
		}
		if (isOn (Scientist, Plate2) || isOn (Engineer, Plate2)){
			if (PlateOn2) {
				PlateOn2 = !PlateOn2;
				code -= 2;
			}
			else{
				PlateOn2 = !PlateOn2;
				code += 2;
			}			
		}
		if (isOn (Scientist, Plate3) || isOn (Engineer, Plate3)){
			if (PlateOn3) {
				PlateOn3 = !PlateOn3;
				code -= 4;
			}
			else{
				PlateOn3 = !PlateOn3;
				code += 4;
			}			
		}
		if (isOn (Scientist, Plate4) || isOn (Engineer, Plate4)){
			if (PlateOn4) {
				PlateOn4 = !PlateOn4;
				code -= 8;
			}
			else{
				PlateOn4 = !PlateOn4;
				code += 8;
			}			
		}
		if (isOn (Scientist, Plate5) || isOn (Engineer, Plate5)){
			if (PlateOn5) {
				PlateOn5 = !PlateOn5;
				code -= 16;
			}
			else{
				PlateOn5 = !PlateOn5;
				code += 16;
			}			
		}
		if (isOn (Scientist, Plate6) || isOn (Engineer, Plate6)){
			if (PlateOn6) {
				PlateOn6 = !PlateOn6;
				code -= 32;
			}
			else{
				PlateOn6 = !PlateOn6;
				code += 32;
			}			
		}

	}
	
	bool isOn(GameObject player_, GameObject plate)
	{
		if (plate.transform.position.x >= (player_.transform.position.x - range) &&
		    plate.transform.position.x <= (player_.transform.position.x + range) && 
		    plate.transform.position.z >= (player_.transform.position.z - range) &&
		    plate.transform.position.z <= (player_.transform.position.z + range))
			return true;
		else
			return false;
	}
}
