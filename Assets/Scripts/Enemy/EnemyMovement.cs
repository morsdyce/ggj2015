using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform target;

	NavMeshAgent agent;
	bool inRange;
	
	void Awake () {
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		agent.SetDestination (target.position);
	}
}
