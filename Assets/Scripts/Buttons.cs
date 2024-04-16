using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    public GameObject ModelPrefab;
    public float scaleIncrement;
    private GameObject[] gameObjects;

    void PressButton() //Senses when an controller touches the object
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Model");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        ModelPrefab.transform.position = this.transform.position;
        Instantiate(ModelPrefab, ModelPrefab.transform.localPosition += new Vector3(-0.3F,0,0), Quaternion.identity);
    }
}

