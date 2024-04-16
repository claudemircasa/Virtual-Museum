using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public float x, y, z;
    private Rigidbody rb;
	// private Transform transform;
    private Vector3 com;
    private float scale;
    void Start()
    {
        scale = GetComponent<Transform>().localScale.x;
        rb = GetComponent<Rigidbody>();
        // transform = GetComponent<Transform>();
        com = new Vector3(x*scale , y*scale , z*scale );

        //Debug.Log(com);

        rb.centerOfMass = com;
        
    }

    private void Update()
    {
        scale = (GetComponent<Transform>().localScale.x);
        com = new Vector3(x*scale, y*scale, z*scale);
        
        rb.centerOfMass = com;
    }
}