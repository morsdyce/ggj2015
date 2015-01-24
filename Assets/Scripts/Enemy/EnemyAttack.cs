using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;     

	Animator anim;
	GameObject player;
	bool playerInRange;
	float timer;
	EnemyMovement enemyMovement;
	
	void Awake (){
		enemyMovement = GetComponent<EnemyMovement> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent <Animator> ();
	}
	
	
	void OnTriggerEnter (Collider other){
		if(other.gameObject == player){
			playerInRange = true;
		}
	}
	
	
	void OnTriggerExit (Collider other){
		if(other.gameObject == player){
			playerInRange = false;
		}
	}
	
	
	void Update (){
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyMovement.enabled /*&& enemyHealth.currentHealth > 0*/) {
						Attack ();
		} else {
				anim.SetBool("Attacking", false);
		}	
	}

	void PlayerAttack(){
		Debug.Log ("player attacking");
	}
	
	
	public void Attack (){
		timer = 0f;
		Debug.Log ("Attack");
		anim.SetBool ("Attacking", true);

		// if enemy movemnt has not been enabled the entity is still in npc dialog state
		// once enemy movement has been enabled mark the enemy as an enemy and remove the NPC layer
		if (!enemyMovement.enabled) {
			enemyMovement.enabled = true;
			gameObject.tag = "Enemy";
			gameObject.layer = 0;
			anim.SetBool("IsActive", true);
		}	
	}
}