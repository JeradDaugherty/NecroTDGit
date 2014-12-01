using UnityEngine;
using System.Collections;

public class TrackingEnemy : BaseEnemy 
{
	//public float cooldownTimer;
	//private bool isCooldown = false;
	//public float cooldownDuration;



	// Use this for initialization
	public override void Start () 
    {
        // Grab the transform of the player
        base.Start();
		cripple = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (stunTrap == null) 
		{
			int x = 5; 
			x++;
		}

		//RunSpeedLogic();
		if (cripple == true) 
		{
			Vector2 direction = player.transform.position - this.transform.position;
			
			// Normalize it
			direction.Normalize ();
			
			this.transform.Translate (direction * Time.deltaTime * crippleSpeed, Space.World);
		} 

		else if (stunned == true && stunTrap != null)
		{
			Vector2 direction = player.transform.position - this.transform.position;
			
			// Normalize it
			direction.Normalize ();
			
			// Use the vector3 to give chase!
			this.transform.Translate (direction * Time.deltaTime * stunTrapped, Space.World);
		}

		else
		{
			Vector2 direction = player.transform.position - this.transform.position;
			
			// Normalize it
			direction.Normalize ();
			
			// Use the vector3 to give chase!
			this.transform.Translate (direction * Time.deltaTime * speed, Space.World);
		}
	}

    public override void AggroPlayer(string tag)
    {
        base.AggroPlayer(tag);

        isAggro = true;
    }

	public void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Crippling Projectile") 
		{
			print ("enteredthevoid");
			cripple = true;
		} 
	}

	public void OnTriggerStay2D(Collider2D trigger)
	{
		if (trigger.tag == "Stunning Trap") 
		{
			print ("OHH SHIT I'm FUCKED");
			stunned = true;
			if (stunTrap == null)
			{
				stunTrap = trigger.gameObject;
			}
		}
	}

	/*private void RunSpeedLogic()
	{
		if (isCooldown == false) 
		{
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
				cripple = false;
			}
		}
	}*/
}
