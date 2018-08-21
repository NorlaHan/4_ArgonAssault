using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour {

    [SerializeField] Color color = Color.green;
    [SerializeField] Vector3 size =new Vector3(2,2,2);

    enum DrawType {WireSphere, WireCube, WireMesh}
    [SerializeField] DrawType drawType = DrawType.WireSphere;
    
    [Header("Wire mesh")]
    [SerializeField][Tooltip("Mesh for wire mesh")] Mesh mesh;
    [SerializeField][Tooltip("Rotation for wire mesh")] Vector3 meshRot;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        if (drawType == DrawType.WireSphere)
        {
            Gizmos.DrawWireSphere (transform.position, size.x);
        }
        else if (drawType == DrawType.WireCube)
        {
            Gizmos.DrawWireCube(transform.position, size);
        }
        else if (drawType == DrawType.WireMesh)
        {
            Gizmos.DrawWireMesh(mesh,transform.position ,Quaternion.Euler(meshRot), size);
        }

        
    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
