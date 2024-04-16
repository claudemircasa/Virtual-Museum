using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

//    private bool CanActivateLaser = true;

    public GameObject laserPrefab;
    public GameObject laserTargetPrefab;
    private GameObject laser;
    private GameObject target;
    public Material targetMaterial;
    public Color color;
    private Transform laserTransform;
    private Vector3 hitPoint;
//    private GameObject gameObject;
    public float scaleIncrement = 0.001F;

    public LayerMask layerMask = 0011111111;



    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Start()
    {
        laser = Instantiate(laserPrefab);
        target = Instantiate(laserTargetPrefab);
        laserTransform = laser.transform;
        laser.GetComponent<MeshRenderer>().material.SetColor("_Color", color);

        target.GetComponent<MeshRenderer>().material = targetMaterial;
    }
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

/*    void SetCanActivateLaer(bool bolean)
    {
        CanActivateLaser = bolean;
    }
*/
    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance);

		if (hit.collider.tag == "Floor") {
			target.transform.position = hit.point;
			/*if(target.transform.up != hit.normal)
            {
                target.transform.rotation = Quaternion.FromToRotation(target.transform.up, hit.normal);
            }*/
			target.SetActive (true);
		} else
			target.SetActive (false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && GetComponent<SteamVR_Teleporter>().teleportOnClick)
        {
            RaycastHit hit;

            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, layerMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
            }
			else
			{
				laser.SetActive(false);
				target.SetActive(false);
			}
            /*if(hit.collider != null && hit.collider.tag != "Floor")
            {
                target.SetActive(false);
            }

            /*gameObject = GameObject.FindGameObjectWithTag(hit.collider.tag);
            if (gameObject && trackedController && Controller.GetAxis().y > 0F)
            {
                Debug.Log("Make me big!");

                gameObject.transform.localScale += new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
            }
            else if (gameObject && Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) && Controller.GetAxis().y < 0F)
            {
                Debug.Log("Make me small!");
                gameObject.transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, scaleIncrement);
            }*/
        }
        else 
        {
            laser.SetActive(false);
            target.SetActive(false);
        }
    }
}
