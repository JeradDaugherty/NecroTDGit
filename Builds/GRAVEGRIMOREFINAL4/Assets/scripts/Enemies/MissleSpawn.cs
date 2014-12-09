using UnityEngine;
using System.Collections;

public class MissleSpawn : BaseEnemy 
{
	public bool isShooting = false;
	public GameObject bulletPrefab;
	public float cooldownTimer;
	private bool isCooldown = false;
	public float cooldownDuration;

	public override void Start () 
	{
		base.Start ();
	}

	void Update () 
	{
		if (isAggro)
			TrackPlayer();
		else if (isShooting)
			RunShootingLogic();
	}

	private void RunShootingLogic()
	{
		// Easy out
		if (player == null)
			return;
		
		if(isCooldown == false)
		{
			// Shoot
			GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity)
				as GameObject;
			
			bullet.GetComponent<EnemyProjectile>().direction = 
				player.transform.position - this.transform.position;
			
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

	private void TrackPlayer()
	{
		// Easy out
		if (player == null)
			return;
		
		Vector3 direction = player.transform.position - this.transform.position;
		direction.Normalize();
		this.transform.Translate(direction * Time.deltaTime * speed, Space.World);
	}

	public override void AggroPlayer(string tag)
	{
		base.AggroPlayer(tag);
		
		if(tag == "Aggro Radius")
		{
			isShooting = false;
			isAggro = true;
		}
		else if(tag == "Projectile Radius")
		{
			isShooting = true;
		}
	}
}
