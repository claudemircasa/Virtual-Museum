using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour {

    private GameObject model;
    private Material material;
    private Texture texture;
    private float scaleIncrement = 0.05f;
    public bool renderTextures = true;
    public bool isLit = true;
	private sculpAreaManager manager;
	// public bool novo = false;

    // Use this for initialization
    void Start () {

		// Lida com a alteração em algumas obras na hora de gerar o modelo 3D
		try {
			manager = transform.parent.Find ("criaModelo").GetComponent<sculpAreaManager> ();
		} catch (System.NullReferenceException) {
			manager = transform.parent.GetComponent<sculpAreaManager> ();
		}
		/*
        model = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetRenderedModel();
        material = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetMaterial();
        texture = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetTexture();
		*/

		model = manager.GetRenderedModel ();
		material = manager.GetMaterial ();
		texture = manager.GetTexture ();

        renderTextures = true;
        material.SetTexture("_MainTex", texture);
        material.shader = Shader.Find("Standard");

    }

    public void Reset()
    {
		/*
        GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().RenderModel();
        model = GetComponent<Transform>().parent.GetComponent<sculpAreaManager>().GetRenderedModel();
        */

		manager.RenderModel ();
		model = manager.GetRenderedModel ();

		// Adicionado para voltar a como estava no início
		renderTextures = true;
		material.SetTexture("_MainTex", texture);
		material.shader = Shader.Find("Standard");
    }

    public void ZoomIn()
    {
        model.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
    }
    public void ZoomOut()
    {
        if (model.transform.localScale.x-scaleIncrement > 0 || model.transform.localScale.y - scaleIncrement > 0 || model.transform.localScale.z - scaleIncrement > 0)
            model.transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
    }

    public void Textures()
    {
        if (renderTextures == true)
            material.SetTexture("_MainTex", null);
        else
            material.SetTexture("_MainTex", texture);

        renderTextures = !renderTextures;
    }

    public void Light()
    {
        if (isLit == true)
            material.shader = Shader.Find("Unlit/Texture");
        else
            material.shader = Shader.Find("Standard");

        isLit = !isLit;
    }

    private void Update()
    {
        if (!model)
        {
			model = manager.GetRenderedModel();
        }
    }

}
