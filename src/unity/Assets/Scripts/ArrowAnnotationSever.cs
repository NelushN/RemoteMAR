using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ArrowAnnotationSever : MonoBehaviour, IPunInstantiateMagicCallback
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject arrow2;
    [SerializeField]
    private GameObject ButtonManager;
    private bool addArrowEnabled = false;
    private GameObject arrowAnnotation;
    private GameObject arrowAnnotation2;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void OnPhotonInstantiate(Photon.Pun.PhotonMessageInfo info)
    {
        Debug.Log("Is this mine?... " + info.Sender.IsLocal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (addArrowEnabled && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            BoxCollider mc = ButtonManager.GetComponent<ButtonManager>().centralObject.GetComponent<BoxCollider>();
            if (!mc.Raycast(ray, out hit, 1000))
            {
                return;
            }
            Vector3 hitVector = hit.point;
            int val = ButtonManager.GetComponent<ButtonManager>().modelDropdown.GetComponent<TMP_Dropdown>().value;

            if (val == 0) // Cube1
            {
                addArrowEnabled = false;
                // Kidney photon view ID is 2
                PhotonView view = PhotonView.Find(3);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                //arrowAnnotation2 = PhotonNetwork.Instantiate(arrow2.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                //arrowAnnotation2.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                Debug.Log("Arrow Name: #########s" + arrow.name);
                //}
                //else
                //{  
                //    arrowAnnotation = PhotonNetwork.Instantiate(arrow2.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                //    arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                //}
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }
            else if (val == 1) // Cube2
            {
                addArrowEnabled = false;
                // Lungs photon ID is 1
                PhotonView view = PhotonView.Find(4);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                // Grabs recently instantiated annotation and sync it with the other player 
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }

            else if (val == 2) // City1
            {
                addArrowEnabled = false;
                // Lungs photon ID is 1
                PhotonView view = PhotonView.Find(6);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }

            else if (val == 3) // City2
            {
                addArrowEnabled = false;
                // Lungs photon ID is 1
                PhotonView view = PhotonView.Find(5);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }
        }

        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("PlayerNumber"))
        {
            int playerNumber = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerNumber"];

            if (playerNumber == 2)
            {
                if (arrowAnnotation != null)
                {
                    Renderer arrowRenderer = arrowAnnotation.GetComponent<Renderer>();
                    if (arrowRenderer != null)
                    {
                        arrowRenderer.material.color = Color.red;
                    }
                }
            }
        }
    }

    // Finds instantiated arrow GameObject from Update() RPC and appends it to the client's parent centralObject
    [PunRPC]
    public void AddArrowLabel(int viewID)
    {
        //arrowAnnotation = PhotonView.Find(viewID).gameObject;
        //arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
        arrowAnnotation = PhotonView.Find(viewID).gameObject;
        //arrowAnnotation2 = PhotonView.Find(viewID).gameObject;
        arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
       // arrowAnnotation2.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);

    }

    public void onClick_AddArrow()
    {
        if (!addArrowEnabled)
        {
            addArrowEnabled = true;
        }
        else
        {
            addArrowEnabled = false;
        }

    }
}
