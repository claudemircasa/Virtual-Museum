using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulateModels : MonoBehaviour {

    GameObject model;
    public float rotationAngle;
    public float incremetnSize;
    public float movementAmount;
    public bool[] isReversed = new bool[3];       //0-x    1-y    2-z
    private int[] Reversed = new int[3];         //0-x    1-y    2-z

    // Use this for initialization
    void Start () {
        model = gameObject;
        for(int i = 0; i < isReversed.Length; i++)
        {
            if (isReversed[i])
            {
                Reversed[i] = -1;
            }
            else
            {
                Reversed[i] = 1;
            }
        }
	}

    /*void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }

    }*/


        // Update is called once per frame
        void Update () {

        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);



        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(0f, rotationAngle * Reversed[1], 0f, Space.Self);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(0f, -rotationAngle * Reversed[1], 0f, Space.Self);
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(rotationAngle * Reversed[0], 0f, 0f, Space.Self);
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(-rotationAngle * Reversed[0], 0f, 0f, Space.Self);
        }
        if ((Input.GetKey(KeyCode.Q)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(0f, 0f, rotationAngle * Reversed[2], Space.Self);
        }
        if ((Input.GetKey(KeyCode.E)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.Rotate(0f, 0f, -rotationAngle * Reversed[2], Space.Self);
        }
        if ((Input.GetKey(KeyCode.R)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.localScale += new Vector3(incremetnSize, incremetnSize, incremetnSize);
        }
        if ((Input.GetKey(KeyCode.F)) && !Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.localScale -= new Vector3(incremetnSize, incremetnSize, incremetnSize);
        }


        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position -= new Vector3(movementAmount, 0f, 0f);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position += new Vector3(movementAmount, 0f, 0f);
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position += new Vector3(0f, 0f, movementAmount);
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position -= new Vector3(0f, 0f, movementAmount);
        }
        if ((Input.GetKey(KeyCode.R)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position += new Vector3(0f, movementAmount, 0f);
        }
        if ((Input.GetKey(KeyCode.F)) && Input.GetKey(KeyCode.LeftControl))
        {
            model.transform.position -= new Vector3(0f, movementAmount, 0f);
        }

    }
}
