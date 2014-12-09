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

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Aggro Radius" || trigger.tag == "Projectile Radius")
        {
            trigger.GetComponentInParent<BaseEnemy>().AggroPlayer(trigger.tag);
        }

		/*if (trigger.tag == "Turret Boost") 
		{

		}*/
    }

	internal void Died()
	{
		Destroy(this.gameObject);
	}
}
