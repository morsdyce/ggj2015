using UnityEngine;
using System.Collections;

public class NearFieldTrigger : MonoBehaviour {
	
	private SphereCollider myCollider;

	// Use this for initialization
	void Start () {
		myCollider = transform.GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {

		Collider[] cols=Physics.OverlapSphere(transform.position,myCollider.radius);

		foreach (Collider col in cols){
			col.SendMessage("PlayerMessage",null,SendMessageOptions.DontRequireReceiver);
		}
	}
}
