using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour 
{
	public GameObject powerUp;
	public Vector2 direction;
	public float rotateSpeed = 180f;
	public float moveSpeed = 1.5f;
	public GameObject owner;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Rotate
		this.transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
		
		// Move it
		this.transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);
	}
	public void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Player") 
		{
			print ("BONUS!");
			powerUp.SetActive (true);
			Destroy (owner);
		}
	}
}
