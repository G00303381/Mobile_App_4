using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{	
	public float health = 100f;
	public float repeatDamagePeriod = 2f;
	public AudioClip[] ouchClips;
	public float hurtForce = 10f;
	public float damageAmount = 40f;

    public float camShakeAmnt = 0.10f;
    public float camShakeLng = 0.2f;
    CameraShake camShake;

    private SpriteRenderer healthBar;
	private float lastHitTime;					
	private Vector3 healthScale;


	void Awake ()
	{
		//playerControl = GetComponent<PlayerControl>();
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		healthScale = healthBar.transform.localScale;

        camShake = GameManager.gm.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.LogError("No camera shake script found on gm object!");
        }
    }


	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				if(health > 0f)
				{
					TakeDamage(col.transform); 
					lastHitTime = Time.time;
                    camShake.shake(camShakeAmnt, camShakeLng);

                }

				else
				{
					GetComponentInChildren<Weapon>().enabled = false;		
				}
			}
		}
	}


	void TakeDamage (Transform enemy)
	{
		// Create a vector that's from the enemy to the player with an upwards boost.
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;

		// Add a force to the player in the direction of the vector and multiply by the hurtForce.
		GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);

		// Reduce the player's health by the damage amount.
		health -= damageAmount;

		// Update what the health bar looks like.
		UpdateHealthBar();

        if (health <= 0)
        {
            GameManager.gameOver = true;
            GameManager.KillPlayer(this);

            if (GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
            {
                GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
            }
        }
	}


	public void UpdateHealthBar ()
	{
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
	}
}
