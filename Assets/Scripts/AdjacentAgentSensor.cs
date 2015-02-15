using UnityEngine;
using System.Collections;

public class AdjacentAgentSensor : MonoBehaviour {
	public ArrayList adjacentAgents;

	public void Sense(Collider2D col, GameObject gameObject) {
		if(col.gameObject.tag == "Agent") {
			float distance = Vector3.Distance(gameObject.transform.position, col.gameObject.transform.position);
			float rotation = Mathf.Abs(gameObject.transform.rotation.eulerAngles.z - col.gameObject.transform.rotation.eulerAngles.z);
			Debug.Log(distance);
			Debug.Log(rotation);
		}
	}
}
