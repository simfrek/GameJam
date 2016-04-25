using UnityEngine;
using System.Collections;

public class SwapCharacter : MonoBehaviour {

	private bool CurrentCharacter = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("swap") < -0.2) 
		{
			light.enabled = !light.enabled;
//			torchOn = true;
//			time = 15;
		}
	}
}
