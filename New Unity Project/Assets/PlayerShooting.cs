using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public float m_fRateOfFire = 0.2f;
	public float m_fProjectileSpeed = 0.3f;
	float m_fAccumulatedFireTime = 0.0f;
	//AudioSource m_pFireSound;
	
	// Use this for initialization
	void Start ()
	{
		//m_pFireSound = (AudioSource)gameObject.AddComponent("AudioSource");
		//m_pFireSound.clip = (AudioClip)Resources.Load("Sounds/Pew") as AudioClip;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// We are going to read the input every frame
		Vector3 vNewInput = new Vector3(Input.GetAxis("RightAnalogX"), 0, Input.GetAxis("Right Analog Y"));
		if(vNewInput.sqrMagnitude < 0.1f)
		{
			// Reset the shooting timing if we stop shooting
			m_fAccumulatedFireTime = 0.0f;
			return;
		}
		
		// Keep track of extra time of shots
		m_fAccumulatedFireTime += Time.deltaTime;
		
		// Broadcast our shooting
		int nNumShotsFired = (int)(m_fAccumulatedFireTime / m_fRateOfFire);
		for(int nShotIter = 0; nShotIter < nNumShotsFired; ++nShotIter)
		{
			// Create a new shot
			GameObject pNewObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			pNewObject.name = " Player_Projectile";
			pNewObject.renderer.material.color = Color.red;
			// Set it's position and rotation to match this object's in world space
			//  and put it on 0.0f 'z-axis' to make sure it'll hit targets
			pNewObject.transform.rotation = transform.rotation;
			Vector3 vTempPos = transform.position;
			pNewObject.transform.position = vTempPos;
			// Scale it to a nice 'magic number' size
			pNewObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			
			// Add the projectile behavior to the object
			Projectile pNewProjectile = (Projectile)pNewObject.AddComponent("Projectile");
			pNewProjectile.Init(m_fProjectileSpeed);
		}
		
		//if(nNumShotsFired > 0)
		//{
		//m_pFireSound.Play();    
		//}
		
		m_fAccumulatedFireTime %= m_fRateOfFire;
	}
}
