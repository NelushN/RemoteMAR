﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CircleAnnotation : MonoBehaviour, IPunInstantiateMagicCallback
{
    [SerializeField]
    private GameObject circle;
    [SerializeField]
    private GameObject ButtonManager;
    private bool addCircleEnabled = false;
    private GameObject circleAnnotation;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void OnPhotonInstantiate(Photon.Pun.PhotonMessageInfo info)
    {
        // Example... 
        Debug.Log("Is this mine?... " + info.Sender.IsLocal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (addCircleEnabled && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            MeshCollider mc = ButtonManager.GetComponent<ButtonManager>().centralObject.GetComponent<MeshCollider>();
            if (!mc.Raycast(ray, out hit, 1000))
            {
                return;
            }
            Vector3 hitVector = hit.point;
            int val = ButtonManager.GetComponent<ButtonManager>().modelDropdown.GetComponent<TMP_Dropdown>().value;
            if (val == 0) // Kidneys
            {
                addCircleEnabled = false;
                PhotonView view = PhotonView.Find(2);
                circleAnnotation = PhotonNetwork.Instantiate(circle.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                circleAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform.parent);
                view.RPC("AddCircleLabel", RpcTarget.Others, circleAnnotation.GetPhotonView().ViewID);
            }
            else if (val == 1) // Lungs
            {
                addCircleEnabled = false;
                PhotonView view = PhotonView.Find(1);
                circleAnnotation = PhotonNetwork.Instantiate(circle.name, hitVector, Quaternion.FromToRotation(Vector3.down, hit.normal));
                circleAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform.parent);
                view.RPC("AddCircleLabel", RpcTarget.Others, circleAnnotation.GetPhotonView().ViewID);
            }
        }
    }

    // Finds instantiated circle GameObject from Update() RPC and appends it to the client's parent centralObject
    [PunRPC]
    public void AddCircleLabel(int viewID)
    {
        circleAnnotation = PhotonView.Find(viewID).gameObject;
        circleAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform.parent);
    }

    public void onClick_AddCircle()
    {
        addCircleEnabled = true;
    }
}