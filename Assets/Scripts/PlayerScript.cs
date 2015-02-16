using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float rotationSpeed;

	
	
	// Use this for initialization
	void Start () {
		
	}
	
	void update() {
		
	}
	
	void OnTriggerStay2D(Collider2D col) {
		AdjacentAgentSensor sensor = gameObject.GetComponent<AdjacentAgentSensor>();
		sensor.Sense(col, gameObject);
	}
	
	void FixedUpdate()
	{
		
		// movement and rotation
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime/5;
		transform.Translate(0, translation, 0);
		transform.Rotate(0, 0, -rotation);

	}
	
}