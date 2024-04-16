using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicationMenu : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;

    public GameObject Menu;
    public bool buttonEnabled = true;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
		Menu.SetActive(buttonEnabled);
    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            if (buttonEnabled == false)
            {
                Menu.SetActive(true);
                buttonEnabled = true;
            }
            else if (buttonEnabled == true)
            {
                Menu.SetActive(false);
                buttonEnabled = false;
            }
        }
    }

}