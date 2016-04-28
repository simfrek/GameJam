
using UnityEngine;
using System.Collections;


public class torch : MonoBehaviour {
	public int health = 600;
	public int healthMax = 600;
	private int time = 0;
	public int regen = 0;
	private bool torchOn = false;
	private string Trigger = "Joy2Triggers";
	// Use this for initialization
	void Start () {
		light.enabled = !light.enabled;
		if (GameObject.FindGameObjectWithTag("SCam").GetComponent<toggleMap>().twoControllers)
			Trigger = "Joy2Triggers";
		else
			Trigger = "Joy1Triggers";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag ("SCam").GetComponent<toggleMap>().twoControllers)
			Trigger = "Joy2Triggers";
		else
			Trigger = "Joy1Triggers";
		if (torchOn == false) 
		{
			if (health > 0 && time == 0) 
			{
				if (GameObject.FindGameObjectWithTag("Engineer").GetComponent<EngineerControllerC>().enabled){
					if (Input.GetAxisRaw (Trigger) > 0.9) 
					{
						light.enabled = !light.enabled;
						torchOn = true;
						time = 60;
					}
				}
			}
			if (time > 0)
				time--;
			if(health < healthMax && regen == 0)
			{
				health ++;
				regen = 5;
			}
			if(regen > 0)
				regen--;
		} 
		else if (torchOn == true) 
		{
			if (health > 0 && time == 0) 
			{
				if (Input.GetAxisRaw(Trigger) > 0.9) 
				{
					light.enabled = !light.enabled;
					torchOn = false;
					time = 60;
				}
				health--;

			} 
			else if (health <= 0) 
			{
				light.enabled = !light.enabled;
				torchOn = false;
			}
			if (time > 0)
				time--;
		} 
	}
}
