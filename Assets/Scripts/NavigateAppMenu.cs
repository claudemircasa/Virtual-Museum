using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateAppMenu : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

	// private bool menuIsActive;
    // private GameObject selectedButton;
    public float ButtonIncrement = 0.001F;
    //private SteamVR_LaserPointer Laser;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

/*
    public void SetMenuActive()
    {
        menuIsActive = true;
    }

    void SelectButton(Collider col)
    {
        if (selectedButton)
            return;
        selectedButton = col.gameObject;
        selectedButton.transform.localScale += new Vector3(ButtonIncrement, ButtonIncrement, ButtonIncrement);

    }

    void DeselectButton()
    {
        if (!selectedButton)
            return;
        selectedButton.transform.localScale -= new Vector3(ButtonIncrement, ButtonIncrement, ButtonIncrement);
        selectedButton = null;

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AppMenuButton")
        {
            SelectButton(other);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "AppMenuButton")
        {
            SelectButton(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "AppMenuButton")
        {
            DeselectButton();
        }
    }

    // Update is called once per frame
    void Update () {

        if (selectedButton && Controller.GetHairTriggerUp())
        {
            selectedButton.SendMessage("PressButton");
            DeselectButton();
        }	
	}*/
}
