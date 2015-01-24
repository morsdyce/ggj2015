using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public int attackDamage = 10;               
	
	
	//	Animator anim;                              
	//	PlayerHealth playerHealth;                  // Reference to the player's health.
	//	EnemyHealth enemyHealth;                    // Reference to this enemy's health.
	bool enemyInRange;                         
	float timer;                                
	
	
	void Awake ()
	{
		// Setting up the references.
		//		playerHealth = player.GetComponent <PlayerHealth> ();
		//		enemyHealth = GetComponent<EnemyHealth>();
		//		anim = GetComponent <Animator> ();
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = false;
		}
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && enemyInRange && Input.GetButtonDown("Fire1") /*&& enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}
		
		// If the player has zero or less health...
		//		if(playerHealth.currentHealth <= 0)
		//		{
		//			// ... tell the animator the player is dead.
		//			anim.SetTrigger ("PlayerDead");
		//		}
	}
	
	
	void Attack ()
	{
		timer = 0f;
		Debug.Log ("Player Attack");
		
		//		// If the player has health to lose...
		//		if(playerHealth.currentHealth > 0)
		//		{
		//			// ... damage the player.
		//			playerHealth.TakeDamage (attackDamage);
		//		}
	}
}