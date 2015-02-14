using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//player speeds
	public float speed;
	public float rotationSpeed;
	public float playerOffset;
	public float sensorLength;

	void update() {

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

	public void Raycast() {

		// raycast for walls in the scene, walls are on layer 8
		Debug.DrawRay (transform.position, this.transform.up * 3.0f, Color.cyan);
		
		// right forward wall sensor
		Vector2 fwdRight = transform.position;
		fwdRight.Set (this.transform.up.x / 2 + this.transform.right.x / 2, this.transform.up.y / 2 + this.transform.right.y / 2);
		Debug.DrawRay (transform.position, fwdRight * sensorLength, Color.cyan);
		
		// left forward wall sensor
		Vector2 fwdLeft = transform.position;
		fwdLeft.Set (this.transform.up.x / 2 + -this.transform.right.x / 2, this.transform.up.y / 2 + -this.transform.right.y / 2);
		Debug.DrawRay (transform.position, fwdLeft * sensorLength, Color.cyan);
		
		RaycastHit2D hitFront = Physics2D.Raycast(transform.position, this.transform.up, sensorLength, 1 << 8);
		RaycastHit2D hitRight = Physics2D.Raycast(transform.position, fwdRight, sensorLength, 1 << 8);
		RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, fwdLeft, sensorLength, 1 << 8);

		hitFront.distance -= playerOffset;
		hitLeft.distance -= playerOffset;
		hitRight.distance -= playerOffset;

		if (hitFront.collider == null)
						hitFront.distance = sensorLength;
		if (hitLeft.collider == null)
						hitLeft.distance = sensorLength;
		if (hitRight.collider == null)
						hitRight.distance = sensorLength;
		Debug.Log ("FrontSensor " + hitFront.distance.ToString("F2") + " " +
		           "RightSensor " + hitRight.distance.ToString("F2") +  " " +
		           "LeftSensor " + hitLeft.distance.ToString("F2"));
	}
}

