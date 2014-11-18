using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
    public int curHealth;
    public int maxHealth;
    public GameObject owner;
    public Image healthDisplay;
    public Transform startPos;

    private HeroController heroController;
	private BulletScript bulletScript;

    private float startingDisplayWidth;

	// Use this for initialization
	void Start ()
    {
        this.transform.position = startPos.position;
        startingDisplayWidth = healthDisplay.rectTransform.rect.width;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void TakeDamage(int amount, Color color)
    {
        // Subtract the health
        curHealth -= amount;

        // Tell the UI to spawn
        UIManager.Instance.CreateDamagePopupText(this.transform, color, amount);

        // Check for death
        if(curHealth <= 0)
        {
                Destroy(owner);
        }
        else
        {
			print("RecalculatingHealth");
			RecalculateHealthDisplay();
        }
    }

    private void RecalculateHealthDisplay()
    {
        // Calculate what percentage health remains (using casting)
        float percentHealth = (float)curHealth / (float)maxHealth;
        //if (percentHealth >= maxHealth / 2)
            healthDisplay.color = Color.Lerp(Color.red, Color.green, percentHealth);
        //else
        //    healthDisplay.color = Color.red;
        healthDisplay.rectTransform.sizeDelta = new Vector2(percentHealth * startingDisplayWidth, healthDisplay.rectTransform.rect.height);
    }
}
