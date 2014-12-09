using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour 
{
    public int minDamage;
    public int maxDamage;
    public Color damageColor;
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

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Enemy")
        {
            trigger.GetComponentInChildren<HealthBar>().TakeDamage(Random.Range(minDamage, maxDamage), damageColor);
            //trigger.GetComponentInChildren<HeroController>().Died();
			Destroy(owner);
        }
    }
}
