using UnityEngine;
using System.Collections;

public class CharMovement : MonoBehaviour {

	public GameObject goTerrain;

	private float dist;
	public float speed = 5f;
	// last click target location
	private Vector3 targetLocation;

	void Start () {
		dist = transform.position.y; // Distance camera is above map
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (goTerrain.collider.Raycast(ray, out hit, Mathf.Infinity)){
				targetLocation = hit.point;
			}
		}

		if (targetLocation != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
		}

	}
}