using UnityEngine;
using System.Collections;

public class TrackingEnemy : BaseEnemy 
{
	// Use this for initialization
	public override void Start () 
    {
        // Grab the transform of the player
        base.Start();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if(isAggro == true && player != null)
        //{
            // Draw a line from A to B
            // B - A
            Vector3 direction = player.transform.position - this.transform.position;

            // Normalize it
            direction.Normalize();

            // Use the vector3 to give chase!
            this.transform.Translate(direction * Time.deltaTime * speed, Space.World);
        //}
	}

    public override void AggroPlayer(string tag)
    {
        base.AggroPlayer(tag);

        isAggro = true;
    }
}
