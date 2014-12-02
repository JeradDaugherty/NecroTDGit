using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour 
{
    private Mover mover;

    public float hSpeed = 4.0f;
    public float vSpeed = 2.0f;

	// Use this for initialization
	void Start ()
    {
        //anim = this.GetComponent<Animator>();
        mover = this.GetComponent<Mover>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        // Let the animator know the player movement
      	//anim.SetBool("isMoving", (horz != 0 || vert != 0));

        // Build the movement vector
        Vector3 dir = Vector3.zero;
        dir.x = horz * hSpeed * Time.deltaTime;
        dir.y = vert * vSpeed * Time.deltaTime;

        // Move the object last
        mover.Move(dir);
	}

    /// <summary>
    /// Plays the next attack queued by the player
    /// </summary>
    /*public void PlayNextAttack()
    {
        weapon.PlayNextAttack();
    }*/

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Aggro Radius" || trigger.tag == "Projectile Radius")
        {
            trigger.GetComponentInParent<BaseEnemy>().AggroPlayer(trigger.tag);
        }
    }

	internal void Died()
	{
		// Find all enemies
		//GameObject[] livingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		
		// Loop through them all, and tell them they have won
		//for(int i = 0; i < livingEnemies.Length; ++i)
		//{
		//	livingEnemies[i].GetComponent<BaseEnemy>().Winner();
		//}
		
		Destroy(this.gameObject);
	}

}
