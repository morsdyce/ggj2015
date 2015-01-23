using UnityEngine;
using System.Collections;

public class CatAnimation : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Awake () {
		anim.SetBool ("walking", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
