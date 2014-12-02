using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public int speed = 6;
	public int minDamage;
	public int maxDamage;
	public int minHeadDamage;
	public int maxHeadDamage;
	public Color damageColor;
	public GameObject owner;

	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{

		if (trigger.tag == "Enemy") 
		{
			print ("YOUHITHIM");
			trigger.GetComponentInChildren<HealthBar> ().TakeDamage (Random.Range (minDamage, maxDamage), damageColor);
			Destroy (owner);
			//trigger.GetComponentInChildren<HeroController>().Died();
}
		else if (trigger.tag == "Enemy Head") 
		{
			print ("HeadShot");
			// getting the parent of the trigger object then finding the script in one of its children and running off of that
			trigger.transform.parent.GetComponentInChildren<HealthBar> ().TakeDamage (Random.Range (minHeadDamage, maxHeadDamage), damageColor);
			Destroy (owner);
		}

		else if (trigger.tag == "Enemy Pig Missles")
		{
			print ("Destroy Projectiles");
			trigger.GetComponentInChildren<HealthBar> ().TakeDamage (Random.Range (minDamage, maxDamage), damageColor);
			Destroy (owner);
		}

	}

	void Start()
	{
		rigidbody2D.velocity = new Vector2 (speed, 0);
	}
	

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
