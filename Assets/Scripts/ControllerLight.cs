using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLight : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTriggerDown())
        {
            GetComponent<Light>().enabled = !(GetComponent<Light>().enabled);
        }
	}
}
