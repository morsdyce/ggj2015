using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;

	Vector3 offset;
	
	void Start () {
		offset = transform.position - target.position;
	}

	void Update () {
		Vector3 cameraPosition = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, cameraPosition, smoothing * Time.deltaTime);
	}
}
