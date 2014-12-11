using UnityEngine;
using System.Collections;

public class PigMissles : MonoBehaviour 
{
	public GameObject owner;
	//public float speed = 6;
	public Vector2 direction;
	public float rotateSpeed = 180f;
	public float moveSpeed = 1.5f;
	public GameObject loseScreen;
	//public GameObject player;


	// Use this for initialization
	void Start () 
	{
		//rigidbody2D.velocity = new Vector2 (speed, 10);
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Player") 
		{
			print ("YOUHITHIM");
			Destroy (owner);
			trigger.GetComponentInChildren<HeroController>().Died();
			loseScreen.SetActive (true);
			
			// Set player to null!
			//player = null;
		}
	}
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		// Rotate
		this.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
		
		// Move it
		this.transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);
	}
}
