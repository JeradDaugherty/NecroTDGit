using UnityEngine;
using System.Collections;

public class UITrapManager : MonoBehaviour 
{
	#region SINGLETON
	// Singleton!
	private static UITrapManager instance;
	
	public static UITrapManager Instance 
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.Find ("Trap Manager").GetComponent<UITrapManager>();
			}
			
			return instance;
		}
	}
	#endregion

	public GameObject damageTrap;
	public GameObject dTrap;
	public GameObject cripplingTrap;
	public GameObject cTrap;
	public GameObject stunningTrap;
	public GameObject sTrap;
	public GameObject trapMenu;

	public void DamageTrap()
	{
		trapMenu.SetActive (false);
		damageTrap.SetActive (true);
		Destroy (gameObject);
		Instantiate (dTrap, transform.position, Quaternion.identity);
	}
	
	public void CripplingTrap()
	{
		trapMenu.SetActive (false);
		cripplingTrap.SetActive (true);
		Destroy (gameObject);
		Instantiate (cTrap, transform.position, Quaternion.identity);
	}
	
	public void StunningTrap()
	{
		trapMenu.SetActive (false);
		stunningTrap.SetActive (true);
		Destroy (gameObject);
		Instantiate (sTrap, transform.position, Quaternion.identity);
	}

	public void TrapMenu()
	{
		trapMenu.SetActive (true);
	}
	// Use this for initialization
	void Start () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		if (trigger.tag == "Player") 
		{
			TrapMenu();
		}
	}

	// Update is called once per frame
	void Update () 
	{

	}

}
