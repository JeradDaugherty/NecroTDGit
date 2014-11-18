using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour 
{
    public int minDamage;
    public int maxDamage;
    public Color damageColor;
    public GameObject bloodParticlePrefab;
    public Vector2 direction;
    public float rotateSpeed = 180f;
    public float moveSpeed = 1.5f;

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
        if (trigger.tag == "Player")
        {
            Instantiate(bloodParticlePrefab, trigger.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            trigger.GetComponentInChildren<HealthBar>().TakeDamage(Random.Range(minDamage, maxDamage), damageColor);
            //trigger.GetComponentInChildren<HeroController>().Died();
        }
    }
}
