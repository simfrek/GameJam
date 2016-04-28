using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {
	private Vector3 direction;
	private Quaternion rotation;
	void Start () {

	}

	void Update ()
	{
		direction = new Vector3(Input.GetAxis ("RightAnalogX"), 0, Input.GetAxis ("Right Analog Y"));
		rotation = Quaternion.LookRotation(direction, Vector3.up);
		transform.rotation = rotation;
	}
}
