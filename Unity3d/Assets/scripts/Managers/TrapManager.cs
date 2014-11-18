using UnityEngine;
using System.Collections;

public class TrapManager : MonoBehaviour 
{
	#region SINGLETON
	//Singleton!
	private static TrapManager instance;
	
	public static TrapManager Instance
	{
		get
		{
			if(instance == null)
				instance = GameObject.Find ("TrapManager").GetComponent<TrapManager>();
			return instance;
		}
	}
	#endregion

	public GameObject[] traps;
	private GameObject curTrap;
	//private int curTrapIndex = 0;

	public void DamageTrap()
	{
		//curTrap = Instantiate (traps [curTrapIndex], Vector3.zero, Quaternion.identity) as GameObject;
		UITrapManager.Instance.DamageTrap ();
	}

	public void CripplingTrap()
	{
		//curTrap = Instantiate (traps [curTrapIndex], Vector3.zero, Quaternion.identity) as GameObject;
		UITrapManager.Instance.CripplingTrap ();
	}

	public void StunningTrap()
	{
		//curTrap = Instantiate (traps [curTrapIndex], Vector3.zero, Quaternion.identity) as GameObject;
		UITrapManager.Instance.DamageTrap ();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
