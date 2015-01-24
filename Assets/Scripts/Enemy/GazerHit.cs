using UnityEngine;
using System.Collections;

public class GazerHit : MonoBehaviour {

	public float damageDelay = 2f;
	public float destroyDelay = 3f;

	bool inRange = false;
	GameObject player;
	GameObject particles;
	//PlayerHealth playerHealth;
	float timer = 0f;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		//playerHealth = player.GetComponent<PlayerHealth> ();
		particles = gameObject.transform.Find ("Particles").gameObject;
	}

	void Start() {
		Invoke ("StartParticles", damageDelay);
		Destroy (gameObject, destroyDelay);
	}

	void StartParticles() {
		particles.SetActive (true);
	}

	void Update() {
		timer += Time.deltaTime;

		if (inRange && timer > damageDelay) {
			timer = 0f;
			Debug.Log("Damaged");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			inRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			inRange = false;
		}
	}
}
