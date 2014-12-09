using UnityEngine;
using System.Collections;

public class DamagePopupText : MonoBehaviour 
{
    public Vector2 lateralVelocityRange;
    public Vector2 upwardsVelocityRange;

	// Use this for initialization
	void Start () 
    {
        this.GetComponent<Rigidbody2D>().AddForce(
            new Vector2(Random.Range(lateralVelocityRange.x, lateralVelocityRange.y),
                Random.Range(upwardsVelocityRange.x, upwardsVelocityRange.y))
            );
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
