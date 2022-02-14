using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MakeMark : MonoBehaviour
{

    public Material OnMaterial;
    public Material OffMaterial;
    public GameObject Marker;
    private GameObject parentObj;
    public SteamVR_Action_Boolean MarkButtonPressed;
    public SteamVR_Input_Sources handType;
    private GameObject childObject;
    private void Start()
    {
        MarkButtonPressed.AddOnStateDownListener(TriggerDown, handType);
        MarkButtonPressed.AddOnStateUpListener(TriggerUp, handType);
        transform.GetComponent<Renderer>().material = OffMaterial;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MarkableData")
        {
            transform.GetComponent<Renderer>().material = OnMaterial;
            parentObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MarkableData")
        {
            parentObj = null;
            transform.GetComponent<Renderer>().material = OffMaterial;
        }

    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (parentObj)
        {
            if (childObject == null)
            {
                childObject = Instantiate(Marker);
                
                childObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
            childObject.transform.position = transform.position;
            childObject.transform.parent = parentObj.transform;
            childObject.tag = "Marker";
            Rigidbody corb = childObject.GetComponent<Rigidbody>();
        }


    }


}
