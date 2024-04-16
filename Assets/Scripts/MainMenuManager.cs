using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour {

    public GameObject Menu;
    public bool buttonEnabled;

    //public Button[] buttons;
    //private int selectedInd;

    // Use this for initialization
    void Start () {
        //buttons[0].Select();		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pressed esc");
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

        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedInd = selectedInd % buttons.Length;
            buttons[selectedInd].Select();
        }*/
    }
}
