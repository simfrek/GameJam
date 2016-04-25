
using UnityEngine;
using System.Collections;


public class torch : MonoBehaviour {
	public int health = 600;
	public int healthMax = 600;
	private int time = 0;
	public int regen = 0;
	private bool torchOn = false;
	// Use this for initialization
	void Start () {
		light.enabled = !light.enabled;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (torchOn == false) 
		{
			if (health > 0 && time == 0) 
			{
				if (Input.GetAxisRaw ("triggers") > 0.9) 
				{
					light.enabled = !light.enabled;
					torchOn = true;
					time = 15;
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
				if (Input.GetAxisRaw ("triggers") > 0.9) 
				{
					light.enabled = !light.enabled;
					torchOn = false;
					time = 15;
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
