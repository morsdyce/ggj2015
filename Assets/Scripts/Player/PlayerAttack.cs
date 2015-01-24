using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

	private Slider lifeBarSlider;
	private GameObject enemyInRange;

	private float lastAttackTime = 0;
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
		if(enemyInRange != null && lastAttackTime + timeBetweenAttacks < Time.time  && Input.GetButtonDown("Fire1")){
			lastAttackTime = Time.time;
			Attack ();
		}
	}

	public void EnemyAttack(){
		health = health -= attackDamage;
		setHealth (health);
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