using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Projectile : MonoBehaviour {


	float m_fProjectileSpeed = 0.5f;
	float m_fProjectileLifeTime = 2.0f;

	public void Init(float fProjectileSpeed)
	{
		// How fast are we going to move?
		m_fProjectileSpeed = fProjectileSpeed;
	}
	// Use this for initialization
	void Start () {
		rigidbody.useGravity = false;
		collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.0f, m_fProjectileSpeed, 0.0f);
		
		m_fProjectileLifeTime -= Time.deltaTime;
		if(m_fProjectileLifeTime < 0.0f)
		{
			// Destroy this projectile after it's life time runs out
			DestroyObject(gameObject);
		}
	}

	void OnTriggerEnter(Collider pOther)
	{
		// We don't hit players
		//if(pOther.gameObject.GetComponent<PlayerMovement>() != null)
			//return;
		
		//        // Tell enemies they were hit                            // Lines to be uncommented after adding the enemy
		//        if(pOther.gameObject.GetComponent<Enemy>() != null)        // Lines to be uncommented after adding the enemy
		//        {                                                        // Lines to be uncommented after adding the enemy
		//            // Tell whatever we hit to take damage                // Lines to be uncommented after adding the enemy
		//            pOther.gameObject.BroadcastMessage("TakeDamage");    // Lines to be uncommented after adding the enemy
		//        }                                                        // Lines to be uncommented after adding the enemy
		
		// Destroy this projectile after collision
		DestroyObject(gameObject);
	}
}
