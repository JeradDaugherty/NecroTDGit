using UnityEngine;
using System.Collections;

public class BaseTarget : MonoBehaviour 
{
	private bool isPaused = false;
	//private PlayerData player;

	public float multiplier = 0f;
	private float timer = 0f;

	public virtual void Start()
	{
		//player = GameObject.FindWithTag ("Player").GetComponent<PlayerData> ();
	}

	public virtual void Update ()
	{
		if (isPaused == true) 
			return;

		timer += Time.deltaTime;

		Vector3 newPos = new Vector3 (this.transform.position.x, (Mathf.Sin (timer)) * multiplier, 0f);
		this.transform.position = newPos;
	}

	public void Pause()
	{
		isPaused = true;
	}

	public void Unpause()
	{
		isPaused = false;
	}

	public virtual void Save(int num)
	{
		// Save the position
		PlayerPrefs.SetFloat("target" + num + "posX", this.transform.position.x);
		PlayerPrefs.SetFloat("target" + num + "posY", this.transform.position.y);
		PlayerPrefs.SetFloat("target" + num + "posZ", this.transform.position.z);
		
		// Save the timer & friends
		PlayerPrefs.SetFloat("target" + num + "timer", timer);
		PlayerPrefs.SetFloat("target" + num + "mult", multiplier);
		
		// Save the 'type' so we know what to instantiate on load
		PlayerPrefs.SetString("target" + num + "type", this.GetType().ToString());
	}

	internal void Load(int num)
	{
		// Get position
		Vector3 pos = Vector3.zero;
		
		pos.x = PlayerPrefs.GetFloat("target" + num + "posX");
		pos.y = PlayerPrefs.GetFloat("target" + num + "posY");
		pos.z = PlayerPrefs.GetFloat("target" + num + "posZ");
		
		// Set it
		this.transform.position = pos;
		
		// Set other variables that were saved
		timer = PlayerPrefs.GetFloat("target" + num + "timer");
		multiplier = PlayerPrefs.GetFloat("target" + num + "mult");
	}
}
