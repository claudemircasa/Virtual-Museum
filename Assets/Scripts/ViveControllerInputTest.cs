﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}
	// Use this for initialization

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	// Update is called once per frame
	void Update () {
		// 1
		if (Controller.GetAxis() != Vector2.zero)
		{
//			Debug.Log(gameObject.name + Controller.GetAxis());
		}

		// 2
		if (Controller.GetHairTriggerDown())
		{
			Debug.Log(gameObject.name + " Trigger Press");
		}

		// 3
		if (Controller.GetHairTriggerUp())
		{
			Debug.Log(gameObject.name + " Trigger Release");
		}

		// 4
		if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
		{
			Debug.Log(gameObject.name + " Grip Press");
		}

		// 5
		if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			Debug.Log(gameObject.name + " Grip Release");
		}
	}
}
