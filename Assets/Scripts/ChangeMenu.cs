using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenu : MonoBehaviour {

	public bool isExit = false;
    public GameObject newMenu;
    private GameObject curentMenu;
	private GameObject[] helpUIs;

	// Use this for initialization
	void Start () {
        curentMenu = transform.parent.gameObject;
	}

    public void ChangeMenuScreen()
    {
        newMenu.SetActive(true);
        curentMenu.SetActive(false);
    }
	public void Exit(){
		Application.Quit ();
	}
	public void toggleHelp(){
		helpUIs = GameObject.FindGameObjectsWithTag ("Help");

		foreach (GameObject helpUI in helpUIs) {
			helpUI.SendMessage("toggleHelp");
		}

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
