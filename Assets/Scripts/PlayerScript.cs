using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//player health
	public int hp = 100;
	public int hp_max = 200;
	public int level;
	public int score = 0;
	public int ammunition = 100;
	public Vector2 pos;
	public Vector2 size;
	public Texture2D emptyTex;
	public Texture2D fullTex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//player speeds
	public float speed = 1F;
	public float rotationSpeed = 0.25F;
	
	
	void FixedUpdate()
	{
		ammunition = PlayerPrefs.GetInt("ammo");

			// movement and rotation
			float translation = Input.GetAxis("Vertical") * speed;
			float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
			translation *= Time.deltaTime/5;
			transform.Translate(0, translation, 0);
			transform.Rotate(0, 0, -rotation);
			
			

			
	}
}

