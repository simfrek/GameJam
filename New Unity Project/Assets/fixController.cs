using UnityEngine;
using System.Collections;

public class fixController : MonoBehaviour {
	private int timer = 0;
	// Use this for initialization
	void Start () {
		var script = GetComponent <ThirdPersonController>();
		script.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 100) {
			GetComponent <ThirdPersonController>().enabled = false;
			enabled = false;
		}
		timer++;
	}
}
