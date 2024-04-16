using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sculpAreaManager : MonoBehaviour {

    public GameObject ModelPrefab;
    private GameObject RenderedModel;
    public Material material;
    public Texture texture;

	// Use this for initialization
	void Start () {
        RenderModel();
    }

    public void RenderModel()
    {
        if (RenderedModel)
            Destroy(RenderedModel);

        RenderedModel = Instantiate(ModelPrefab, GetComponent<Transform>(), false);
    }

    public GameObject GetRenderedModel()
    {
        return RenderedModel;
    }

    public Material GetMaterial()
    {
        return material;
    }

    public Texture GetTexture()
    {
        return texture;
    }


    // Update is called once per frame
    void Update () {
		
	}
}