using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabItem : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;
	private GameObject controllerHint;
    public float scaleIncrement = 0.001F;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
		controllerHint = transform.GetChild (2).gameObject;
        //Laser = GetComponent<SteamVR_LaserPointer>();
    }

    private void SetCollidingObject(Collider col)
    {
        GameObject tmpObject = null;
        if (collidingObject)
        {
            return;
        }
        if (col.tag == "ModelCol")
            tmpObject = col.gameObject.transform.parent.gameObject;
        else
            tmpObject = col.gameObject;

        if (!tmpObject.GetComponent<Rigidbody>())
            return;
        else
            collidingObject = tmpObject;
    }
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        Controller.TriggerHapticPulse(1000);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        GetComponent<SteamVR_Teleporter>().teleportOnClick = false;
		if (controllerHint)
			controllerHint.SendMessage ("updateTouchpadHelp");
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 15000;
        fx.breakTorque = 15000;
        return fx;
    }
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            var Velocity = new Vector3();
            Velocity.x = Controller.velocity.z;
            Velocity.y = Controller.velocity.y;
            Velocity.z = -Controller.velocity.x;


            objectInHand.GetComponent<Rigidbody>().velocity = Velocity;

            Velocity.x = Controller.angularVelocity.z;
            Velocity.y = Controller.angularVelocity.y;
            Velocity.z = -Controller.angularVelocity.x;

            Debug.Log(Velocity);
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Velocity;
        }
        objectInHand = null;
        GetComponent<SteamVR_Teleporter>().teleportOnClick = true;
		if(controllerHint)
			controllerHint.SendMessage ("updateTouchpadHelp");
    }
    // Update is called once per frame
    void Update () {
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }

        if (objectInHand && Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().y > 0F)
        {
            //Debug.Log("Make me big!");
            objectInHand.transform.localScale += 4*new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
        }
        else if (objectInHand && Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().y < 0F)
        {
            //Debug.Log("Make me small!");
            objectInHand.transform.localScale -= 4*new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
        }
    }
}
