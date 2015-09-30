using UnityEngine;
using System.Collections;

public class NodeTemplate : MonoBehaviour {

    [SerializeField]
    protected Material nodeMat;
    [SerializeField]
    protected Mesh nodeMesh; 
    protected MeshFilter meshr;
    protected MeshRenderer rendr;

}
