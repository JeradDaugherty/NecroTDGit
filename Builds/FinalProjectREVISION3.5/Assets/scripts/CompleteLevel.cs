using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.transform.childCount == 0)
			GameManager.Instance.LevelComplete ();
	}
}
