using UnityEngine;
using System.Collections;

public class PieSensorScript : MonoBehaviour {

    public float range = 3F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        GameObject[] agents = GameObject.FindGameObjectsWithTag("Agent");
        
        for (int i = 0; i < agents.Length; i++) {
            Vector3 distance = agents[i].transform.position - gameObject.transform.position;

            if (distance.magnitude <= range)
            {
                Debug.Log(agents[i].name + " is within " + range + " units.");
                //Vector3.Angle(gameObject.transform.ro
            }
        }
    }
}