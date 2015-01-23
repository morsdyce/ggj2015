using UnityEngine;
using System.Collections;

public class TheOthersHandler : MonoBehaviour {

	private GameObject player;

	private Behaviour halo;
	private float turnOffHaloTime = 0f;
	private DialogBubble dialog;
	private bool isNearPlayer = false;
	private float notNearPlayerTime = 0f;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		Debug.Log ("Click fired");
		dialog.showDialogMessage ();

		if (isNearPlayer) {
			player.SendMessage("setHealth",50,SendMessageOptions.DontRequireReceiver);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (notNearPlayerTime != 0f) {
			if(Time.time > notNearPlayerTime){
				halo.enabled = false;
				notNearPlayerTime = 0f;
				isNearPlayer = false;
			} else {
				halo.enabled = true;
			}
		}
	}
	
	void Awake() {

		halo = this.GetComponent ("Halo") as Behaviour;
		dialog = GetComponent<DialogBubble> ();
		player = GameObject.FindWithTag ("Player");
	}

	// received as message from other objects
	void PlayerMessage(){
		isNearPlayer = true;
		notNearPlayerTime = Time.time + 0.5f; // add two seconds delay for when to turn off halo
	}

}
