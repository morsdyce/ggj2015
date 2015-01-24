using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;     
	public int attackDamage = 10;               
	
	
//	Animator anim;                              
	GameObject player;                          
//	PlayerHealth playerHealth;                  
//	EnemyHealth enemyHealth;                    
	bool playerInRange;                         
	float timer;                                
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag ("Player");
//		playerHealth = player.GetComponent <PlayerHealth> ();
//		enemyHealth = GetComponent<EnemyHealth>();
//		anim = GetComponent <Animator> ();
	}
	
	
	void OnTriggerEnter (Collider other)
	{

		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	
	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0*/)
		{
			Attack ();
		}
		

//		if(playerHealth.currentHealth <= 0)
//		{
//			// ... tell the animator the player is dead.
//			anim.SetTrigger ("PlayerDead");
//		}
	}
	
	
	void Attack ()
	{
		timer = 0f;
//		Debug.Log ("Attack");
		
//		// If the player has health to lose...
//		if(playerHealth.currentHealth > 0)
//		{
//			// ... damage the player.
//			playerHealth.TakeDamage (attackDamage);
//		}
	}
}