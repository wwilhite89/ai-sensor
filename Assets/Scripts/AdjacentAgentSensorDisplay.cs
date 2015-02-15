using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class AdjacentAgentSensorDisplay : MonoBehaviour {
	ArrayList agents;
	Text text;

	// Use this for initialization
	void Start () {
		agents = GameObject.FindGameObjectWithTag("Player").GetComponent<AdjacentAgentSensor>().adjacentAgents;
		text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "";
		text.text = "Adjact Agent Sensor:\n";
		foreach(Vector2 agent in agents) {
			text.text += "Agent " + agent.GetHashCode();
			text.text += ": (" + agent.x + ", " + agent.y + ")\n";
		}
	}
}
