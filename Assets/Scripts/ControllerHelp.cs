	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControllerHelp : MonoBehaviour {

	public bool showHelp = true;
	private bool isHoldingItem = false;

	public void toggleHelp(){
		showHelp = !showHelp;
		transform.GetChild(0).gameObject.SetActive(showHelp);
	}
	public void hideHelp(){
		if (showHelp) {
			transform.GetChild(0).gameObject.SetActive(false);
			showHelp = !showHelp;
		}
	}
	public void updateTouchpadHelp(){
		Text helpText;
		isHoldingItem = !isHoldingItem;
		if (isHoldingItem) {
			transform.GetChild (1).gameObject.SetActive (true);
			helpText = transform.GetChild (0).GetChild (1).GetChild (0).GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();
			helpText.text = "Aperte + para aumentar a escultura\n Aperte - para diminuir a escultura.";
		} else {
			transform.GetChild (1).gameObject.SetActive (false);
			helpText = transform.GetChild (0).GetChild (1).GetChild (0).GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>();
			helpText.text = " Aponte e clique\n para teleportar";
		}
	}
}