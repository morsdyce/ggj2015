using UnityEngine;
using System.Collections;

public class GlowTrigger : MonoBehaviour {

	private Behaviour halo;
	private bool isNearPlayer = false;
	GameObject player;

	void Awake() {	
		halo = this.GetComponent ("Halo") as Behaviour;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			isNearPlayer = true;
		}
	}
	
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			isNearPlayer = false;
		}
	}


	void Update(){
		halo.enabled = isNearPlayer;
	}
}
