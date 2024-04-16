using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderModel : MonoBehaviour {

    public GameObject ModelPrefab;
    public float height;
    private GameObject[] gameObjects;
    private GameObject HMD;
    private GameObject renderedModel;
    private Transform pos;

    public void spawnModel() //Senses when an controller touches the object
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Model");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        HMD = GameObject.FindWithTag("MainCamera");
        renderedModel = Instantiate(ModelPrefab, ModelPrefab.transform.localPosition, HMD.transform.rotation);

        renderedModel.transform.position = HMD.transform.position + Vector3.Scale(new Vector3(1f, 0f, 1f), (HMD.transform.forward / 1.2f));


        //Instantiate(ModelPrefab, ModelPrefab.transform.localPosition, Quaternion.identity);
        renderedModel.transform.Rotate(new Vector3(0f,180f,0f));
        renderedModel.transform.position = new Vector3(renderedModel.transform.position.x, height, renderedModel.transform.position.z);        
    }
}