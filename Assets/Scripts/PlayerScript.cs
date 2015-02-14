using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//player speeds
	public float speed;
	public float rotationSpeed;

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

		RaycastHit2D hit = Physics2D.Raycast(transform.position, this.transform.up, 3.0f, 1 << 8);
		Debug.DrawRay (transform.position, this.transform.up * 3.0f, Color.cyan);

		if (hit.collider != null) {
						float distance = Mathf.Abs (hit.point.y - transform.position.y);
	
						Debug.Log ("The dist is " + distance.ToString("F2"));
				}


	}
}

