using UnityEngine;
using System.Collections;

public class UnitSpawner : MonoBehaviour {

    Tester tester;
    public NodeTemplate[] units;

	// Use this for initialization
	void Start () {

        tester = GetComponent<Tester>();

	}
	
	public void SpawnUnit(int unitIndex)
    {
        NodeTemplate unit = Instantiate(units[unitIndex],tester.spawn.position, Quaternion.identity) as NodeTemplate;
        unit.GetComponent<TankNode>().SetWaypoints(tester.waypoints);
    }
}
