using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;     

	Animator anim;
	GameObject player;
	bool playerInRange;
	private float lastAttackTime = 0;
	EnemyMovement enemyMovement;
	DialogBubble dialogBubble;
	
	void Awake (){
		enemyMovement = GetComponent<EnemyMovement> ();
		dialogBubble = GetComponent<DialogBubble> ();
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

		if(dialogBubble.isSeenOnce && !enemyMovement.enabled){
			// if enemy movemnt has not been enabled the entity is still in npc dialog state
			// once enemy movement has been enabled mark the enemy as an enemy and remove the NPC layer
			enemyMovement.enabled = true;
			gameObject.tag = "Enemy";
			gameObject.layer = 0;
			anim.SetBool("IsActive", true);
			// don't start the attack right away
			lastAttackTime = Time.time;
		}

		if (playerInRange && lastAttackTime != 0 && lastAttackTime + timeBetweenAttacks < Time.time && enemyMovement.enabled) {
			Debug.Log("attaced!");
			lastAttackTime = Time.time;
			anim.SetBool ("Attacking", true);
			Attack ();
		} else {
			anim.SetBool("Attacking", false);
		}	
	}

	void PlayerAttack(){
		Debug.Log ("player attacking");
	}
	
	
	void Attack (){
		player.SendMessage ("EnemyAttack");
	}
}