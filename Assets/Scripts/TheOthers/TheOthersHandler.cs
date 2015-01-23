﻿using UnityEngine;
using System.Collections;

public class TheOthersHandler : MonoBehaviour {

	private Behaviour halo;
	private float turnOffHaloTime = 0f;
	private DialogBubble dialog;

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown() {
		Debug.Log ("Click fired");
		dialog.showDialogMessage ();
	}
	
	// Update is called once per frame
	void Update () {
		if (turnOffHaloTime != 0f && Time.time > turnOffHaloTime) {
			halo.enabled = false;
			turnOffHaloTime = 0f;
		}
	}
	
	void Awake() {
		halo = this.GetComponent ("Halo") as Behaviour;
		dialog = GetComponent<DialogBubble> ();
	}

	// received as message from other objects
	void PlayerMessage(){
		halo.enabled = true;
		turnOffHaloTime = Time.time + 0.5f; // add two seconds delay for when to turn off halo
	}

}
