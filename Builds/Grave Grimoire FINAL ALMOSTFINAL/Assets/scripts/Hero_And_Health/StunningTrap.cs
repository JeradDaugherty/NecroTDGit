using UnityEngine;
using System.Collections;

public class StunningTrap : MonoBehaviour 
{
	public float waitTime;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.tag == "Enemy")
		{
			print ("INSIDE");
			Destroy (this.gameObject, waitTime);
		}
	}
	
}
