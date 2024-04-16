using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clickManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private bool isSelected = false;
    private Button button;
    GameObject EventSystem;



    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        EventSystem = GameObject.Find("EventSystem");
    }

    private void Start()
    {
        button = this.gameObject.GetComponent<Button>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "VrController")
        {
            //Debug.Log("AppMenuButton pressed");
            trackedObj = other.GetComponent<SteamVR_TrackedObject>();
            isSelected = true;
            button.Select();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "VrController")
        {
            isSelected = true;
            button.Select();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "VrController")
        {
            EventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
            isSelected = false;
        }
    }

    private void Update()
    {
        if (trackedObj && Controller.GetHairTriggerDown() && isSelected)
        {
            //Debug.Log("hard trigger down");
            isSelected = false;
            button.onClick.Invoke();
        }
    }
}
