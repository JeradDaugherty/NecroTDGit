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
		if (stunTrap != null) 
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

		else if (stunned == true /*&& stunTrap != null*/)
		{
			Vector2 direction = player.transform.position - this.transform.position;
			
			// Normalize it
			direction.Normalize ();

			this.transform.Translate (direction * Time.deltaTime * stunTrapped, Space.World);
		}

		else
		{
			print("Normal speed");
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

	public IEnumerator StunnedBitch ()
	{
		stunned = true;
		yield return new WaitForSeconds (5f);
		stunned = false;
		yield break;
	}

	public IEnumerator CrippleBitch()
	{
		cripple = true;
		yield return new WaitForSeconds (2.5f);
		cripple = false;
		yield break;
	}

	public void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Crippling Projectile") 
		{
			print ("enteredthevoid");
			StartCoroutine("CrippleBitch");
		} 

		if (trigger.tag == "Stunning Trap") 
		{
			print ("OHH SHIT I'm FUCKED");

			StartCoroutine("StunnedBitch");
		}

		if (trigger.tag == "Player") 
		{
			print ("YOUHITHIM");
			trigger.GetComponentInChildren<HeroController>().Died();
			loseScreen.SetActive (true);
			
			// Set player to null!
			//player = null;
		}
	}
}
