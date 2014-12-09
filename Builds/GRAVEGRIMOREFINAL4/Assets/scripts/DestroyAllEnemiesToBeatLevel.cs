using UnityEngine;
using System.Collections;

public class DestroyAllEnemiesToBeatLevel : MonoBehaviour 
{
	public GameObject winScreen;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) 
		{
			winScreen.SetActive (true);
		}
	}
}
