using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour 
{
    public bool isAggro = false;
    public float speed = 2.0f;

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

        // Set player to null!
        player = null;
    }
}
