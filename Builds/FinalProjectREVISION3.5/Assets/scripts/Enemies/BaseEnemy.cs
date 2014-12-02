using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour 
{
    public bool isAggro = false;
    public float speed = 2.0f;
	public float crippleSpeed = 2.0f;
	public bool cripple;
	public float stunTrapped = 2.0f;
	public bool stunned = false;
	public GameObject stunTrap = null;
	public GameObject loseScreen;

    protected GameObject player;

	// Use this for initialization
	public virtual void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

	public void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Player") 
		{
			trigger.GetComponentInChildren<HeroController>().Died();
		}
	}
    // All enemies can receive, but children classes can execute differently
    public virtual void AggroPlayer(string tag)
    {
        print(this.gameObject.name + " has seen the player!");
    }

	internal void Winner()
	{
		// Spawn particles to taunt player
		Vector3 position = this.transform.position;
		position.y += 1.5f;
		loseScreen.SetActive (true);
		
		// Set player to null!
		player = null;
	}

}
