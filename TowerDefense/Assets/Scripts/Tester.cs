using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

    public Transform spawn;
    public TankNode Tank;
    public GameObject[] waypts;
    public Vector3[] waypoints;

	// Use this for initialization
	void Start () {
        //waypts = GameObject.FindGameObjectsWithTag("Waypoint");

        waypoints = new Vector3[waypts.Length];
        for(int count = 0; count < waypts.Length; count++)
        {
            Debug.Log(waypts[count].name);
            waypoints[count] = waypts[count].transform.position;
        }
    }
}
