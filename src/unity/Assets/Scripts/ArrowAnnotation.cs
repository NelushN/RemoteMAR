using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ArrowAnnotation : MonoBehaviour, IPunInstantiateMagicCallback
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private GameObject ButtonManager;
    private bool addArrowEnabled = false;
    private GameObject arrowAnnotation;
    public NetworkManager networkManager;
    public int player = 0;


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
        player = networkManager.playerNumber;
        Debug.Log("---##########333 PhotonNetwork.LocalPlayer1 " + addArrowEnabled);
        if (addArrowEnabled && Input.GetMouseButtonDown(0))
        {
            Debug.Log("---##########333 PhotonNetwork.LocalPlayer2 " + PhotonNetwork.LocalPlayer);
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
                Debug.Log("---##########333 PhotonNetwork.LocalPlayer3 " + PhotonNetwork.LocalPlayer);
                addArrowEnabled = false;
                PhotonView view = PhotonView.Find(2);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                MeshRenderer[] childMeshRenderers = arrowAnnotation.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer childRenderer in childMeshRenderers)
                {
                    if (player == PhotonNetwork.LocalPlayer.ActorNumber)
                    {
                        Material newMaterial = new Material(childRenderer.sharedMaterial);
                        newMaterial.color = Color.green;
                        childRenderer.material = newMaterial;
                    }
                }
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }
            else if (val == 1) // Cube2
            {
                addArrowEnabled = false;
                // Lungs photon ID is 1
                PhotonView view = PhotonView.Find(100);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);

                MeshRenderer[] childMeshRenderers = arrowAnnotation.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer childRenderer in childMeshRenderers)
                {
                    if (player == PhotonNetwork.LocalPlayer.ActorNumber)
                    {
                        Material newMaterial = new Material(childRenderer.sharedMaterial);
                        newMaterial.color = Color.green;
                        childRenderer.material = newMaterial;
                    }
                }
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }

            else if (val == 2) // City1
            {
                addArrowEnabled = false;
                // Lungs photon ID is 1
                PhotonView view = PhotonView.Find(200);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                MeshRenderer[] childMeshRenderers = arrowAnnotation.GetComponentsInChildren<MeshRenderer>();
                int player = 0;
                player = networkManager.playerNumber;

                foreach (MeshRenderer childRenderer in childMeshRenderers)
                {
                    if (player == PhotonNetwork.LocalPlayer.ActorNumber)
                    {
                        Material newMaterial = new Material(childRenderer.sharedMaterial);
                        newMaterial.color = Color.green;
                        childRenderer.material = newMaterial;
                    }
                }
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }

            else if (val == 3) // City2
            {
                addArrowEnabled = false;
                PhotonView view = PhotonView.Find(10);
                arrowAnnotation = PhotonNetwork.Instantiate(arrow.name, hitVector, Quaternion.FromToRotation(Vector3.up, hit.normal));
                arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
                int player = 0;
                player = networkManager.playerNumber;

                MeshRenderer[] childMeshRenderers = arrowAnnotation.GetComponentsInChildren<MeshRenderer>();

                foreach (MeshRenderer childRenderer in childMeshRenderers)
                {
                    if (player == PhotonNetwork.LocalPlayer.ActorNumber)
                    {
                        Material newMaterial = new Material(childRenderer.sharedMaterial);
                        newMaterial.color = Color.green;
                        childRenderer.material = newMaterial;
                    }
                }
                // Grabs recently instantiated annotation and sync it with the other player
                view.RPC("AddArrowLabel", RpcTarget.Others, arrowAnnotation.GetPhotonView().ViewID);
            }

        }


    }

    // Finds instantiated arrow GameObject from Update() RPC and appends it to the client's parent centralObject
    [PunRPC]
    public void AddArrowLabel(int viewID)
    {

        arrowAnnotation = PhotonView.Find(viewID).gameObject;
        arrowAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
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
