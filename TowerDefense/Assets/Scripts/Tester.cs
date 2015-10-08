using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

    public Transform spawn;
    public TankNode Tank;
    public GameObject[] waypts;
    Vector3[] waypoints;

	// Use this for initialization
	void Start () {
        //waypts = GameObject.FindGameObjectsWithTag("Waypoint");

        waypoints = new Vector3[waypts.Length];
        for(int count = 0; count < waypts.Length; count++)
        {
            Debug.Log(waypts[count].name);
            waypoints[count] = waypts[count].transform.position;
        }
        //Debug.Break();
        StartCoroutine(SpawnTanks(3));
    }
    IEnumerator SpawnTanks(int num)
    {
        for(int count = 0; count< num; count++)
        {
            TankNode tank = Instantiate(Tank, spawn.position, spawn.rotation) as TankNode;
            tank.SetWaypoints(waypoints);
            yield return new WaitForSeconds(5);
        }
    }
}
