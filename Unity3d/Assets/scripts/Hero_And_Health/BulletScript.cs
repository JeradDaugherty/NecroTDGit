using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public int speed = 6;
	public int minDamage;
	public int maxDamage;
	public Color damageColor;

	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnTriggerEnter2D(Collider2D trigger)
	{

		if (trigger.tag == "Enemy")
		{
			print ("YOUHITHIM");
			trigger.GetComponentInChildren<HealthBar>().TakeDamage(Random.Range(minDamage, maxDamage), damageColor);
			//trigger.GetComponentInChildren<HeroController>().Died();
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
