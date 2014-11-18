using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	#region SINGLETON
	//Singleton!
	private static GameManager instance;

	public static GameManager Instance
	{
		get
		{
			if(instance == null)
				instance = GameObject.Find ("Manager Object").GetComponent<GameManager>();
			return instance;
		}
	}
	#endregion

	public GameObject[] levels;
	private GameObject curLevel;
	private int curLevelIndex = 0;

	public void StartNewGame()
	{
		curLevel = Instantiate (levels [curLevelIndex], Vector3.zero, Quaternion.identity) as GameObject;
		UIManager.Instance.StartNewGame ();
	}

	public void LoadGame()
	{
		if (PlayerPrefs.HasKey ("totalPoints") == false) 
		{
			GameObject.Find ("Message Text").GetComponent<Text>().text = "No Saves found.";
			return;
		}

		GameObject level = new GameObject ();
		level.AddComponent<CompleteLevel> ();
		curLevelIndex = PlayerPrefs.GetInt ("levelNumber");
		level.name = "Level " + curLevelIndex;

		curLevel = level;

		UIManager.Instance.StartNewGame ();
	}

	public void LevelComplete()
	{
		Destroy (curLevel);
		if (++curLevelIndex >= levels.Length) 
		{

		}
		else 
		{
			curLevel = Instantiate (levels[curLevelIndex], Vector3.zero, Quaternion.identity) as GameObject;
		}
	}

	public void SaveGame()
	{
		SaveTargets ();
		SavePlayerData ();
	}

	private void SavePlayerData()
	{

		PlayerPrefs.SetInt ("levelNumber", curLevelIndex);
	}

	private void SaveTargets()
	{
		BaseTarget[] allTargets = GameObject.FindObjectsOfType<BaseTarget> ();

		PlayerPrefs.SetInt ("targetCount", allTargets.Length);

		for (int i = 0; i < allTargets.Length; ++i) 
		{
			allTargets[i].Save(i);
		}
	}
	public void Quit()
	{
		Destroy (curLevel);
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
