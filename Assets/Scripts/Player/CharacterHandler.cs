using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHandler : MonoBehaviour {

	public GameObject goTerrain;
	
	public float speed = 5f;
	// last click target location
	private Vector3 targetLocation = new Vector3(-100,-100,-1);

	private Slider lifeBarSlider;

	private float health = 100f;

	void Start () {}

	void Awake(){
		lifeBarSlider = GameObject.FindWithTag("HealthBar").GetComponent("Slider") as Slider;
	}

	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (goTerrain.collider.Raycast(ray, out hit, Mathf.Infinity)){
				targetLocation = hit.point;
				targetLocation.y = 0.54f;
			}
		}

		if (targetLocation.x != -100 && targetLocation.y != -100) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetLocation, step);
		}

	}

	void setHealth(float newValue){
		health = newValue;
		lifeBarSlider.value = health;
	}
}