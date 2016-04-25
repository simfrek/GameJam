using UnityEngine;
using System.Collections;

public class DoorOpenerX : MonoBehaviour {
	public GameObject door;
	private GameObject Scientist;
	private GameObject Engineer;
	private GameObject Player;
	public GameObject otherPlate;

	public string XYZ = "x";
	public bool TwoPlates;
	public bool ConstOpen;
	private float range = 0;
	public bool isOpen = false;
	public float distance = 6;
	private Vector3 open;
	private Vector3 close;
	// Use this for initialization
	void Start () {
		Scientist = GameObject.FindGameObjectWithTag ("Scientist");
		Engineer = GameObject.FindGameObjectWithTag ("Engineer");
		Player = GameObject.FindGameObjectWithTag ("Player");
		range = (transform.localScale.x + transform.localScale.z) /2;
		if (TwoPlates)
			ConstOpen = false;
		if (XYZ == "x" || XYZ == "X") {
			open = new Vector3 (door.transform.position.x - distance, door.transform.position.y, door.transform.position.z);
			close = new Vector3 (door.transform.position.x, door.transform.position.y, door.transform.position.z);
		}
		else
		if (XYZ == "y" || XYZ == "Y") {
			open = new Vector3 (door.transform.position.x, door.transform.position.y - distance, door.transform.position.z);
			close = new Vector3 (door.transform.position.x, door.transform.position.y, door.transform.position.z);
		}
		else
		if (XYZ == "z" || XYZ == "Z") {
			open = new Vector3 (door.transform.position.x, door.transform.position.y, door.transform.position.z - distance);
			close = new Vector3 (door.transform.position.x, door.transform.position.y, door.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (TwoPlates) {
			if (!ConstOpen)
			{
				if ( ((isOn (Scientist, gameObject) && isOn (Engineer, otherPlate)) || 
					(isOn (Scientist, otherPlate) && isOn (Engineer, gameObject))) ) {
					isOpen = true;
					ConstOpen = true;
					Debug.Log ("PermOpen");;
				}
				else if ( (isOn (Scientist, gameObject) || isOn(Engineer, gameObject) || isOn(Scientist, otherPlate) || isOn(Engineer, otherPlate) ) && isOpen == false)
				{
					isOpen = true;
					Debug.Log ("open");
					MoveDoor(open);
				}
				else if ( (!isOn (Scientist, gameObject) && !isOn(Engineer, gameObject) && !isOn(Scientist, otherPlate) && !isOn(Engineer, otherPlate) ) && isOpen == true)
				{
					isOpen = false;
					Debug.Log ("close");
					MoveDoor(close);
				}
			}
		} else {
			if (ConstOpen) {
				if ((isOn (Scientist, gameObject) || isOn (Engineer, gameObject)) && isOpen == false) {
					isOpen = true;
					Debug.Log ("open");
					MoveDoor(open);
				}
			} else {
				if ((isOn (Scientist, gameObject) || isOn (Engineer, gameObject)) && isOpen == false) {
					isOpen = true;
					Debug.Log ("open");
					MoveDoor(open);
				} else 
				if ((!isOn (Scientist, gameObject) && !isOn (Engineer, gameObject)) && isOpen == true) {
					isOpen = false;
					Debug.Log ("close");
					MoveDoor(close);
				}
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

	void MoveDoor(Vector3 move)
	{
		door.transform.position = move;
	}
}


