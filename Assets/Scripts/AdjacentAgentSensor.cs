using UnityEngine;
using System.Collections;

public class AdjacentAgentSensor : MonoBehaviour {
	public ArrayList adjacentAgents = new ArrayList();

	public void Sense(Collider2D col, GameObject gameObject) {
//		adjacentAgents = new ArrayList();
		if(col.gameObject.tag == "Agent") {
			float distance = Vector3.Distance(gameObject.transform.position, col.gameObject.transform.position);
			float rotation = Mathf.Abs(gameObject.transform.rotation.eulerAngles.z - col.gameObject.transform.rotation.eulerAngles.z);
			Vector2 vector = new Vector2(distance, rotation);
			adjacentAgents.Add(vector);
//			Debug.Log(distance);
//			Debug.Log(rotation);
		}
	}
}
