using UnityEngine;
using System.Collections;

public class UnitPlacer : MonoBehaviour {

    public NodeTemplate[] units;
    Camera viewCamera;
    public NodeTemplate placeholder;
    int planeWidth;
    int planeHeight;
    bool canPlace;
    int currentUnit;
    bool isPlacing;

	void Start()
    {
        canPlace = false;
        viewCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        if(isPlacing)
        {
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            Plane ground = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;
            Vector3 rawPosition;

            if (ground.Raycast(ray, out rayDistance))
            {
                rawPosition = ray.GetPoint(rayDistance);
                Debug.DrawLine(ray.origin, rawPosition, Color.red);
                Vector3 newPos = new Vector3(Mathf.Round(rawPosition.x), Mathf.Round(rawPosition.y), Mathf.Round(rawPosition.z));
                newPos.y += .5f;
                Debug.DrawLine(ray.origin, newPos, Color.green);
                placeholder.transform.position = newPos;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Place();
            }
            
        }

	}

    void StartPlacing(int unitIndex)
    {
        isPlacing = true;
        currentUnit = unitIndex;
        placeholder = Instantiate(units[currentUnit]);
        placeholder.enabled = true;
        placeholder.GetComponent<TurretNode>().enabled = false;
    }

    void Place()
    {
        placeholder.GetComponent<TurretNode>().enabled = true;
        StartPlacing(currentUnit);
    }

    public void StopPlacing()
    {
        if(isPlacing)
        {
            isPlacing = false;
            Destroy(placeholder.gameObject);
        }
    }

    public void ReplaceUnit(int unitIndex)
    {
        if(placeholder != null)
            Destroy(placeholder.gameObject);
        StartPlacing(unitIndex);
    }

}
