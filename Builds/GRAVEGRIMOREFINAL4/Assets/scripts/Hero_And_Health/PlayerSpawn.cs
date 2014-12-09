using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour 
{
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		player.transform.position = this.transform.position;	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
