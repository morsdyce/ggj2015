using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

	private Slider lifeBarSlider;
	private GameObject enemyInRange;

	private float lastAttackTime;
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	private int health = 100;

	void Awake ()
	{
		lifeBarSlider = GameObject.FindWithTag("HealthBar").GetComponent("Slider") as Slider;
	}
	
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = other.gameObject;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			enemyInRange = null;
		}
	}
	
	
	void Update ()
	{
		if(enemyInRange != null && Time.time + timeBetweenAttacks >= lastAttackTime && Input.GetButtonDown("Fire1")){
			lastAttackTime = Time.time;
			Attack ();
		}
	}

	void EnemyAttack(){
		Debug.Log ("enemy attacking");
		setHealth (20);
	}
	
	
	void Attack ()
	{
		if (enemyInRange != null) {
			enemyInRange.SendMessage("PlayerAttack");
		}
	}

	void setHealth(int newValue){
		health = newValue;
		lifeBarSlider.value = health;
	}

}