using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	#region SINGLETON
	// Singleton!
	private static UIManager instance;

	public static UIManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.Find ("Manager Object").GetComponent<UIManager>();
			}

			return instance;
		}
	}
	#endregion

	public Text scoreGui;
	private bool isPaused = false;

	public GameObject inGameMenu;
	public GameObject mainMenu;
	private GameManager gameManager;
	public GameObject damagePopupPrefab;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			TogglePaused();
		}
	}

	public void TogglePaused()
	{
		GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();

		isPaused = !isPaused;

		inGameMenu.SetActive (isPaused);

		for (int i = 0; i < allObjects.Length; ++i) 
		{
			if(isPaused == true)
				allObjects[i].SendMessage("Pause", SendMessageOptions.DontRequireReceiver);
			else
				allObjects[i].SendMessage("Unpause", SendMessageOptions.DontRequireReceiver);
		}
	}

	internal void StartNewGame()
	{
		mainMenu.SetActive (false);
		scoreGui.transform.root.gameObject.SetActive (true);
	}

	public void quit()
	{
		scoreGui.transform.root.gameObject.SetActive (false);
		mainMenu.SetActive (true);
		TogglePaused ();
	}

	public void CreateDamagePopupText(Transform location, Color color, int amount)
	{
		GameObject popup = Instantiate(damagePopupPrefab, location.position, damagePopupPrefab.transform.rotation) as GameObject;
		
		Text damageText = popup.GetComponentInChildren<Text>();
		damageText.color = color;
		damageText.text = amount.ToString();
	}
}
