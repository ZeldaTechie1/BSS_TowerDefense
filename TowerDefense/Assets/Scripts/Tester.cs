using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

    public Transform spawn;
    public TankNode Tank;
    GameObject[] waypts;
    Vector3[] waypoints;

	// Use this for initialization
	void Start () {
        waypts = GameObject.FindGameObjectsWithTag("Waypoint");

        waypoints = new Vector3[waypts.Length];
        int pos = waypts.Length - 1;
        for(int count = 0; count < waypts.Length; count++)
        {
            waypoints[pos--] = waypts[count].transform.position;
        }
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
