using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class ColorController : MonoBehaviourPunCallbacks, IPunObservable
{
    public Color color = Color.white;
    public MeshRenderer meshRenderer;
    private Color defaultColor;
    private bool colorEnabled = false;
    public GameObject currentHitObj;
    public GameObject colorCube;
    public Color oldColor;
    public int viewId;

    private PhotonView parentPhotonView;

    private void Awake()
    {
        ///parentPhotonView = transform.GetComponent<PhotonView>();
        parentPhotonView = PhotonView.Find(viewId);
    }

    public void OnPhotonInstantiate(Photon.Pun.PhotonMessageInfo info)
    {
        Debug.Log("Is this mine?... " + info.Sender.IsLocal.ToString());
    }

    void Update()
    {
        parentPhotonView = PhotonView.Find(viewId);
        if (parentPhotonView != null && parentPhotonView.IsMine) {
            if (colorEnabled == false && Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits;
                hits = Physics.RaycastAll(ray);
                BoxCollider mc = GetComponent < BoxCollider > ();
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                meshRenderer = hits[0].transform.gameObject.GetComponent < MeshRenderer > ();

                if (hits[0].transform.gameObject.name != "model8" || hits[0].transform.gameObject.name != "model9" || hits[0].transform.gameObject.name != "model10" || hits[0].transform.gameObject.name != "model11") {

                    if (hits[0].transform.gameObject.layer == hits[0].collider.gameObject.layer) {

                        meshRenderer = hits[0].transform.gameObject.GetComponent < MeshRenderer > ();
                        defaultColor = oldColor;
                        color = meshRenderer.material.color;
                        color = Color.white;

                        oldColor = defaultColor;
                        colorEnabled = true;

                        parentPhotonView.RPC("SetColor", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer, (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), hits[0].transform.gameObject.name);

                    }
                }
            }
            else if (meshRenderer.material.color == Color.white && Input.GetMouseButtonDown(0) && colorEnabled == true) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits;
                hits = Physics.RaycastAll(ray);

                BoxCollider mc = GetComponent < BoxCollider > ();
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (hits[0].transform.gameObject.layer == hits[0].collider.gameObject.layer) {
                    meshRenderer = hits[0].transform.gameObject.GetComponent < MeshRenderer > ();
                    meshRenderer.material.color = oldColor;
                    colorEnabled = false;

                    parentPhotonView.RPC("SetColor", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer, (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), hits[0].transform.gameObject.name);
                }
            }
        }
    }

    [PunRPC]
    private void SetColor(Player player, byte r, byte g, byte b, string colorCubeName)
    {
        if (player == PhotonNetwork.LocalPlayer) {

            int childCount = parentPhotonView.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                GameObject child = parentPhotonView.transform.GetChild(i).gameObject;
                if (child.name == colorCubeName) {
                    MeshRenderer childRenderer = child.GetComponent < MeshRenderer > ();
                    if (childRenderer != null) {
                        childRenderer.material.color = new Color32(255, 255, 255, 255);

                    }
                }
            }
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) {
            stream.SendNext(255);
            stream.SendNext(255);
            stream.SendNext(255);
        }
        else {
            color.r = (float)stream.ReceiveNext();
            color.g = (float)stream.ReceiveNext();
            color.b = (float)stream.ReceiveNext();
        }
    }
}
// JavaScript source code
