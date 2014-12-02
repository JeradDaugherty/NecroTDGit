using UnityEngine;
using System.Collections;

public class DamagePopup : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		this.GetComponentInChildren<HealthBar> ().TakeDamage (Random.Range (5, 15), Color.black);
	}
}
