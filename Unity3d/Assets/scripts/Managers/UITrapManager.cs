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
	public GameObject cripplingTrap;
	public GameObject stunningTrap;
	public GameObject trapMenu;

	public void DamageTrap()
	{
		trapMenu.SetActive (false);
		damageTrap.SetActive (true);
		Destroy (gameObject);
	}
	
	public void CripplingTrap()
	{
		trapMenu.SetActive (false);
		cripplingTrap.SetActive (true);
		Destroy (gameObject);
	}
	
	public void StunningTrap()
	{
		trapMenu.SetActive (false);
		stunningTrap.SetActive (true);
		Destroy (gameObject);
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
			OnMouseDown();
		}
	}
	void OnMouseDown()
	{
		TrapMenu (); 
	}

	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit))
			{
				TrapMenu();
			}
		}*/
	}

}
