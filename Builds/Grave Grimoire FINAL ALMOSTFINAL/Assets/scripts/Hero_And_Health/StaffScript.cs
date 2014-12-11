using UnityEngine;
using System.Collections;

public class StaffScript : MonoBehaviour 
{
	public GameObject bullet;
	public float cooldownTimer;
	private bool isCooldown = false;
	public float cooldownDuration;
	public bool isShooting = false;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//RunShootingLogic ();
			isShooting = true;
		}
		if (isShooting)
			RunShootingLogic ();

	}

	private void RunShootingLogic()
	{
		if (isCooldown == false) 
		{
			GameObject tempBullet = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
			Vector2 destination = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 origin = new Vector2(transform.position.x, transform.position.y);
			tempBullet.GetComponent<BulletScript> ().direction = (destination - origin).normalized;
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
			{
				isCooldown = false;
				isShooting = false;
			}
		}
	}
}
