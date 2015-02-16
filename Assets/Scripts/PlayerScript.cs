﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	public float playerOffset;
	public float sensorLength;


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

		Raycast (); // call my raycasting method
	}

	// create three raycasting sensors
	public void Raycast() {

		// vectors to hold sensor right offset and left offset
		Vector2 fwdRight = transform.position;
		Vector2 fwdLeft = transform.position;

		// set the sensor offsets
		fwdRight.Set (this.transform.up.x / 2 + this.transform.right.x / 2, this.transform.up.y / 2 + this.transform.right.y / 2);
		fwdLeft.Set (this.transform.up.x / 2 + -this.transform.right.x / 2, this.transform.up.y / 2 + -this.transform.right.y / 2);


		// Debug rays drawn in scene view  ***********  May want to remove  ************
		Debug.DrawRay (transform.position, this.transform.up * 3.0f, Color.cyan);
		Debug.DrawRay (transform.position, fwdRight * sensorLength, Color.cyan);
		Debug.DrawRay (transform.position, fwdLeft * sensorLength, Color.cyan);

		// three raycasts fwd, left and right.
		// theses rays will only sense objects in layer 8, that is where the walls live
		RaycastHit2D hitFront = Physics2D.Raycast(transform.position, this.transform.up, sensorLength, 1 << 8);
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, fwdRight, sensorLength, 1 << 8);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, fwdLeft, sensorLength, 1 << 8);

		// for accuracy and readability, player offset is the radious of its collider
		hitFront.distance -= playerOffset;
		hitLeft.distance -= playerOffset;
		hitRight.distance -= playerOffset;

		// return the sensor length if the sensor does not sense a wall/ other collider
		if (hitFront.collider == null)
						hitFront.distance = sensorLength;
		if (hitLeft.collider == null)
						hitLeft.distance = sensorLength;
		if (hitRight.collider == null)
						hitRight.distance = sensorLength;

		// print the distances found to the console
//		Debug.Log ("FrontSensor " + hitFront.distance.ToString("F2") + " " +
//		           "RightSensor " + hitRight.distance.ToString("F2") +  " " +
//		           "LeftSensor " + hitLeft.distance.ToString("F2"));
	}
}

