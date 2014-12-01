using UnityEngine;
using System.Collections;

public class DamageTrap : MonoBehaviour 
{
	public GameObject enemy;
	public bool isShooting = false;
	public GameObject bulletPrefab;
	public float cooldownTimer;
	private bool isCooldown = false;
	public float cooldownDuration;
	public GameObject owner;

	// Use this for initialization
	void Start () 
	{
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isShooting)
			RunShootingLogic();
	}
	private void RunShootingLogic()
	{
		// Easy out
		if (enemy == null)
			return;
		
		if(isCooldown == false)
		{
			// Shoot
			GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity)
				as GameObject;
			
			bullet.GetComponent<EnemyProjectile>().direction = 
				enemy.transform.position - this.transform.position;
			
			// Set cooldown timer and bool
			cooldownTimer = cooldownDuration;
			isCooldown = true;
		}
		else
		{
			// Lower timer
			cooldownTimer -= Time.deltaTime;
			
			// Check to see if the timer is over
			if (cooldownTimer <= 0)
				isCooldown = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D trigger)
	{
		print(this.gameObject.name + " has seen the player!");

		if (trigger.tag == "Enemy") 
		{
			isShooting = true;
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy")
			Destroy (owner);
	}
}
