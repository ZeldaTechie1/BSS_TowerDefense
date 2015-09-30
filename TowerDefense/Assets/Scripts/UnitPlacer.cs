using UnityEngine;
using System.Collections;

public class UnitPlacer : MonoBehaviour {

    public NodeTemplate[] units;
    Camera viewCamera;
    public GameObject placeholder;
    int planeWidth;
    int planeHeight;
    int unitPos;
    bool canPlace;

	void Start()
    {
        canPlace = false;
        viewCamera = Camera.main;
        placeholder = Instantiate(placeholder);
    }
	
	// Update is called once per frame
	void Update () {

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up,Vector3.zero);
        float rayDistance;
        Vector3 rawPosition;

        if(ground.Raycast(ray, out rayDistance))
        {
            rawPosition = ray.GetPoint(rayDistance);
            Debug.DrawLine(ray.origin,rawPosition,Color.red);
            Vector3 newPos = new Vector3(Mathf.Round(rawPosition.x),Mathf.Round(rawPosition.y), Mathf.Round(rawPosition.z));
            newPos.y += .5f;
            Debug.DrawLine(ray.origin,newPos, Color.green);
            placeholder.transform.position = newPos;
        }

	    if(canPlace)
        {
            if(Input.GetMouseButtonDown(0))
            {
                //PlaceUnit();
            }
        }
	}

    public void UnitCache(int unit)
    {
        unitPos = unit;
        canPlace = true;
    }

    public void StopPlacing()
    {
        canPlace = false;
    }

    public void PlaceUnit(Vector3 position)
    {

    }

}
