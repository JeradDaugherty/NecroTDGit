using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour 
{
	public float waitTime;

	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, waitTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
