/* Written by Kaz Crowe */
/* PlayerHealth.cs */
using UnityEngine;
using System.Collections;
using TMPro;

	public class P1_PlayerHealth : MonoBehaviour
	{
		static P1_PlayerHealth instance;
		public static P1_PlayerHealth Instance { get { return instance; } }
		bool canTakeDamage = true;

		public int maxHealth = 100;
		float currentHealth = 0;
		public float invulnerabilityTime = 0.5f;

		float currentShield = 0;
		public int maxShield = 25;
		float regenShieldTimer = 0.0f;
		public float regenShieldTimerMax = 1.0f;

		public SimpleHealthBar healthBar;
		public SimpleHealthBar shieldBar;

	
		void Awake ()
		{
			// If the instance variable is already assigned, then there are multiple player health scripts in the scene. Inform the user.
			if( instance != null )
				Debug.LogError( "There are multiple instances of the Player Health script. Assigning the most recent one to Instance." );
			
			// Assign the instance variable as the Player Health script on this object.
			instance = GetComponent<P1_PlayerHealth>();
		}

		void Start ()
		{
			// Set the current health and shield to max values.
			currentHealth = maxHealth;
			currentShield = maxShield;

			// Update the Simple Health Bar with the updated values of Health and Shield.
			healthBar.UpdateBar( currentHealth, maxHealth );
			shieldBar.UpdateBar( currentShield, maxShield );
		}

		void Update ()
		{
			// If the shield is less than max, and the regen cooldown is not in effect...
			if( currentShield < maxShield && regenShieldTimer <= 0 )
			{
				// Increase the shield.
				currentShield += Time.deltaTime * 5;

				// Update the Simple Health Bar with the new Shield values.
				shieldBar.UpdateBar( currentShield, maxShield );
			}

			// If the shield regen timer is greater than zero, then decrease the timer.
			if( regenShieldTimer > 0 )
				regenShieldTimer -= Time.deltaTime;
		}

		public void HealPlayer ()
		{
			// Increase the current health by 25%.
			currentHealth += ( maxHealth / 4 );

			// If the current health is greater than max, then set it to max.
			if( currentHealth > maxHealth )
				currentHealth = maxHealth;

			// Update the Simple Health Bar with the new Health values.
			healthBar.UpdateBar( currentHealth, maxHealth );
		}

    public GameObject Spark;
    public GameObject LightRing;
    public Transform Sword_t;

    void Explode()
    {
        GameObject spark = Instantiate(Spark, Sword_t.position, Quaternion.identity);
        spark.GetComponent<ParticleSystem>().Play();
    }


    void ShieldExplode()
    {
        GameObject LR = Instantiate(LightRing, Sword_t.position, Quaternion.identity);
        LR.GetComponent<ParticleSystem>().Play();
    }

    public void TakeDamage(int damage, bool effects)
    {
        // If the player can't take damage, then return.
        if (canTakeDamage == false)
            return;

        // If the shield value is greater than 0...
        if (currentShield > 0)
        {
            //Shield ring
            if (effects)
            {
                ShieldExplode();
                Explode();
            }

            // Reduce the current shield value.
            currentShield -= damage;

            // If the shield is now less than 0...
            if (currentShield < 0)
            {
                //Blood Explode
                if (effects)
                {
                    Explode();
                }

                // Reduce the health by how much damage went past the shield.
                currentHealth -= currentShield * -1;

                // Set the shield to zero.
                currentShield = 0;
            }
        }
        // Else there was no shield, so reduce health.
        else
        {
            if (effects)
            {
                Explode();
            }

            currentHealth -= damage;

            // If the health is less than zero...
            if (currentHealth <= 0)
            {
                // Set the current health to zero.
                currentHealth = 0;

                // Run the Death function since the player has died.
                Death();
            }
        }

        // Set canTakeDamage to false to make sure that the player cannot take damage for a brief moment.
        canTakeDamage = false;

        // Run the Invulnerablilty coroutine to delay incoming damage.
        StartCoroutine("Invulnerablilty");

        // Update the Health and Shield status bars.
        healthBar.UpdateBar(currentHealth, maxHealth);
        shieldBar.UpdateBar(currentShield, maxShield);

        // Reset the shield regen timer.
        regenShieldTimer = regenShieldTimerMax;
    }

    public TMP_Text RedText;

    public void Death ()
    {
        RedText.gameObject.SetActive(true);

        // Destroy this game object.
        Destroy(gameObject);
    }

    IEnumerator Invulnerablilty ()
		{
			// Wait for the invulnerability time variable.
			yield return new WaitForSeconds( invulnerabilityTime );

			// Then allow the player to take damage again.
			canTakeDamage = true;
		}
	}