using UnityEngine;
using System.Collections;

public class LandNode : NodeTemplate {

    void Start()//This just sets all the values for all the variables both in this class and the NodeTemplate class
    {
        meshr = GetComponent<MeshFilter>();
        rendr = GetComponent<MeshRenderer>();
        meshr.mesh = nodeMesh;//sets the mesh
        rendr.material = nodeMat;//sets the material
    }

    void Update()
    {

    }
	
}
