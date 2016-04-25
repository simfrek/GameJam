using UnityEngine;
using System.Collections;

public class toggleMap : MonoBehaviour {
	public GameObject cameraMap;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("triggers") < -0.2) {
			cameraMap.camera.enabled = !cameraMap.camera.enabled;
		}
	}
}
