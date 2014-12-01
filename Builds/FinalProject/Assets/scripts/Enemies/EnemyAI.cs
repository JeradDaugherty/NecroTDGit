using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform Target;
	private GameObject Enemy;
	private GameObject Player;
	public float Range;
	public float Speed;


	// Use this for initialization
	void Start () 
	{
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Range = Vector2.Distance (Enemy.transform.position, Player.transform.position);
		if (Range <= 15f) 
		{
			transform.Translate (Vector2.MoveTowards (Enemy.transform.position, Player.transform.position, Range)* Speed * Time.deltaTime);	
		}
	}
}
