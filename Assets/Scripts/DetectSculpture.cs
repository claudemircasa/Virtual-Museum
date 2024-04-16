using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSculpture : MonoBehaviour {
    // Use this for initialization

	/** Não utilizado **
	private GameObject[] gameObjects;
	private GameObject thisGameObject;
    private Transform ControlPanelTransform;
    */
    public bool isLocked = false;


    void Start () {
		/** Não utilizado **
        // thisGameObject = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetRenderedModel();
		thisGameObject = transform.parent.GetComponent<sculpAreaManager> ().GetRenderedModel ();
		ControlPanelTransform = GetComponent<Transform>().parent.GetComponent<Transform>().GetChild(0);
		// ControlPanelTransform = transform.parent.Find ("PlacaInfo");
		*/

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ModelCol" && !isLocked)
        {
            /*gameObjects = GameObject.FindGameObjectsWithTag("SculptSpot");			//Este trecho do codigo destrava as outras esculturas
            for (int i = 0; i < gameObjects.Length; i++)								//depois que o usuario solta a escultura que estava segurando
            {																			//na area apropriada
                gameObjects[i].GetComponent<DetectSculpture>().isLocked = false;
			}*/
            Debug.Log("sculpture back");
            GetComponent<MeshRenderer>().material.SetColor("_Color", Color.cyan);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "ModelCol" && !isLocked)
        {
            /*gameObjects = GameObject.FindGameObjectsWithTag("SculptSpot");			//Este trecho trava as outras esculturas no lugar sempre que o
            for (int i = 0; i < gameObjects.Length; i++)								//usuario tirar uma escultura do lugar
            {
                if(gameObjects[i] != gameObject)
                    gameObjects[i].GetComponent<DetectSculpture>().isLocked = true;
            }
            //thisGameObject.GetComponent<Rigidbody>().isKinematic = false;*/

            Debug.Log("sculpture out");
            GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        }
    }


    // Update is called once per frame
    void Update () {
        /*if (!thisGameObject)
        {
            thisGameObject = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetRenderedModel();
        }

        thisGameObject.GetComponent<Rigidbody>().isKinematic = isLocked;*/
    }
}
