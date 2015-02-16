using UnityEngine;
using System.Collections;
using System.Linq;

public class PieSensorScript : MonoBehaviour {

    public float range = 3F;
    public Vector3 startDir = new Vector3(0, 1, 0);

    enum Slice
    {
        TOP_RIGHT = 0,
        TOP_LEFT = 1,
        BOTTOM_RIGHT = 2,
        BOTTOM_LEFT = 3
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate() {
        
        // Draw some pie slices...make toggleable
        // Debug.DrawRay(transform.position, this.transform.up * range, Color.yellow);
        // Debug.DrawRay(transform.position, -this.transform.up * range, Color.yellow);
        // Debug.DrawRay(transform.position, -this.transform.up * range, Color.yellow);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(
                string.Format(
                "Printing activation levels for Pie Sensor...\n" +
                "TOP_RIGHT={0}\nTOP_LEFT={1}\nBOTTOM_RIGHT={2}\nBOTTOM_LEFT={3}\n",
                getActivationLevel(Slice.TOP_RIGHT),
                getActivationLevel(Slice.TOP_LEFT),
                getActivationLevel(Slice.BOTTOM_RIGHT),
                getActivationLevel(Slice.BOTTOM_LEFT)));
        }

    }

    /// <summary>
    /// Returns the number of agents in an activation level given a slice.
    /// </summary>
    /// <param name="slice">Slice area relative to the main agent</param>
    /// <returns>Number activation levels</returns>
    private int getActivationLevel(Slice slice) {
        int levels = 0;
        float offsetRotation = transform.rotation.eulerAngles.z;
        
        
        foreach (var agent in this.getObjectsInRadius("Agent"))
        {
            Vector3 objDir = (agent.transform.position - gameObject.transform.position).normalized;
            objDir.z = 0;

            float angle = Vector3.Angle(startDir, objDir);

            if (Vector3.Cross(startDir, objDir).z < 0)
                angle = 180 + (180 - angle);

            float relativeAngle = (360.0f + angle - transform.eulerAngles.z) % 360.0f;

            switch (slice) {
                case Slice.TOP_LEFT:
                    levels += relativeAngle >= 0.0f && relativeAngle < 90.0f ? 1 : 0;
                    break;
                case Slice.BOTTOM_LEFT:
                    levels += relativeAngle >= 90.0f && relativeAngle < 180.0f ? 1 : 0;
                    break;
                case Slice.BOTTOM_RIGHT:
                    levels += relativeAngle >= 180.0f && relativeAngle < 270.0f ? 1 : 0;
                    break;
                case Slice.TOP_RIGHT:
                    levels += relativeAngle > 270.0f ? 1 : 0;
                    break;
                default:
                    break;
            }
        }

        return levels;
    }

    private GameObject[] getObjectsInRadius(string agentName) {
        Vector3 pos = gameObject.transform.position;

        var agents = GameObject.FindGameObjectsWithTag(agentName)
            .Where(x => Mathf.Abs((x.transform.position - pos).magnitude) <= this.range)
            .ToArray();

        return agents;
    }

}