using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalScrollManager : MonoBehaviour {

    public float scrollSensitivity;
    public GameObject VRController;

    SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private Scrollbar bar;
    // Use this for initialization

    void Awake()
    {
        trackedObj =  VRController.GetComponent<SteamVR_TrackedObject>();
        bar = gameObject.GetComponent<Scrollbar>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isActiveAndEnabled && Controller.GetAxis().y > 0F)
        {
            //Debug.Log("Scroll Up");
            bar.value += scrollSensitivity;
        }
        else if (isActiveAndEnabled && Controller.GetAxis().y < 0F)
        {
            //Debug.Log("Scroll Down");
            bar.value -= scrollSensitivity;
        }
    }
}
