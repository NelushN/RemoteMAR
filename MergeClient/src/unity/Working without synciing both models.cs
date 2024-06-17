﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class ColorController : MonoBehaviourPunCallbacks, IPunObservable
{
    public Color color = Color.white;
    public MeshRenderer meshRenderer = null;
    private Color defaultColor;
    private bool colorEnabled = false;
    public GameObject currentHitObj;
    public GameObject colorCube;
    public Color oldColor;
    public int viewId;

    private PhotonView parentPhotonView;

    private void Awake()
    {
        //parentPhotonView = transform.GetComponent<PhotonView>();
        parentPhotonView = PhotonView.Find(viewId);
        //parentPhotonView = PhotonView.Get(photonView);
    }

    public void OnPhotonInstantiate(Photon.Pun.PhotonMessageInfo info)
    {
        Debug.Log("Is this mine?... " + info.Sender.IsLocal.ToString());
    }

    void Update()
    {
        parentPhotonView = PhotonView.Find(viewId);
        Debug.Log("---101--------parentPhotonView  " + parentPhotonView);
        Debug.Log("---102--------parentPhotonView  " + parentPhotonView.IsMine);
        if (parentPhotonView != null && parentPhotonView.IsMine)
        {
            //  color = meshRenderer.material.color;
            if (colorEnabled == false && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits;
                hits = Physics.RaycastAll(ray);
                BoxCollider mc = GetComponent<BoxCollider>();
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log("---27--------parentPhotonView  " + parentPhotonView);


                if (hits.Length > 0)
                {
                    meshRenderer = hits[0].transform.gameObject.GetComponent<MeshRenderer>();
                    Debug.Log("---23--------  " + hits[0].transform.gameObject.name);
                    if (hits[0].transform.gameObject.name == "model8" || hits[0].transform.gameObject.name == "model9")
                    {
                        mc.enabled = false;
                        Debug.Log("---266-------- mc.enabled " + mc.enabled);
                    }
                    if (hits[0].transform.gameObject.name != "model8" || hits[0].transform.gameObject.name != "model9")
                    {

                        Debug.Log("---25  ");
                        if (hits[0].transform.gameObject.layer == hits[0].collider.gameObject.layer)
                        {
                            Debug.Log("---24  ");
                            meshRenderer = hits[0].transform.gameObject.GetComponent<MeshRenderer>();
                            defaultColor = oldColor;
                            color = Color.white;
                            colorEnabled = true;
                            Debug.Log("---10-------old color  " + oldColor);
                            Debug.Log("---11-------color  " + color);
                            Debug.Log("---12--------defaultcolor  " + defaultColor);
                            Debug.Log("---26--------parentPhotonView  " + meshRenderer);
                            Debug.Log("---23  ");
                            parentPhotonView.RPC("SetColor", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer, (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), hits[0].transform.gameObject.name);
                            ////____ meshRenderer = null;
                            Debug.Log("---26--------PhotonNetwork.LocalPlayer " + PhotonNetwork.LocalPlayer);
                            //  }
                        }
                    }
                }
            }

            else if (color == Color.white && Input.GetMouseButtonDown(0) && colorEnabled == true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits;
                hits = Physics.RaycastAll(ray);

                BoxCollider mc = GetComponent<BoxCollider>();
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (hits.Length > 0)
                {
                    if (hits[0].transform.gameObject.name == "model8" || hits[0].transform.gameObject.name == "model9")
                    {
                        mc.enabled = false;
                        Debug.Log("---256-------- mc.enabled " + mc.enabled);
                    }

                    meshRenderer = hits[0].transform.gameObject.GetComponent<MeshRenderer>();
                    if (hits[0].transform.gameObject.name != "model8" || hits[0].transform.gameObject.name == "model9")
                    {
                        if (hits[0].transform.gameObject.layer == hits[0].collider.gameObject.layer)
                        {
                            Debug.Log("---2  ");

                            meshRenderer = hits[0].transform.gameObject.GetComponent<MeshRenderer>();
                            oldColor = meshRenderer.material.color;
                            colorEnabled = false;

                            parentPhotonView.RPC("SetColor", RpcTarget.AllBuffered, PhotonNetwork.LocalPlayer, (byte)(color.r * 255), (byte)(color.g * 255), (byte)(color.b * 255), hits[0].transform.gameObject.name);
                        }
                    }
                }
            }
        }
    }

    [PunRPC]
    private void SetColor(Player player, byte r, byte g, byte b, string colorCubeName)
    {
        Debug.Log("---##########333 PhotonNetwork.LocalPlayer " + PhotonNetwork.LocalPlayer);
        Debug.Log("---##########333 player " + player);
        //if (player == PhotonNetwork.LocalPlayer)
        //{
        Debug.Log("---##########333  ");
        int childCount = parentPhotonView.transform.childCount;
        Debug.Log("---31--------parentPhotonView  " + parentPhotonView);
        if (meshRenderer != null)
        {
            for (int i = 0; i < childCount; i++)
            {
                //  Debug.Log("---28--------parentPhotonView  " + meshRenderer.name);

                GameObject child = parentPhotonView.transform.GetChild(i).gameObject;
                // Debug.Log("---29--------child " + meshRenderer.name);
                Debug.Log("---30--------colorCubeName  " + colorCubeName);
                if (meshRenderer.name == colorCubeName)
                {
                    Debug.Log("---1--------r  " + r);
                    Debug.Log("---2--------g  " + g);
                    Debug.Log("---3--------b  " + b);
                    //  MeshRenderer childRenderer = child.GetComponent<MeshRenderer>();
                    if (meshRenderer != null)
                    {
                        if (meshRenderer.materials.Length > 1)
                        {
                            Debug.Log("##################### meshRenderer.materials.Length 89" + meshRenderer.materials.Length);
                            meshRenderer.materials[0].color = new Color32(255, 255, 255, 255);
                            meshRenderer.materials[1].color = new Color32(255, 255, 255, 255);
                            //childRenderer.material.color = new Color32(255, 255, 255, 255);
                        }

                        else
                            Debug.Log("##################### meshRenderer.materials.Length 65" + meshRenderer.materials.Length);
                        {
                            meshRenderer.material.color = new Color32(255, 255, 255, 255);
                        }

                        Debug.Log("##################### childRenderer color45" + meshRenderer.material.color);
                    }
                }
            }
        }
        //}
        //else 
        //{
        //    Color color = new Color32(255, 255, 255, 255);
        //    Debug.Log("---##########444 not i f PhotonNetwork.LocalPlayer " + PhotonNetwork.LocalPlayer); 
        //}


    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("---32--------DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        Debug.Log("---32--------parentPhotonView  " + parentPhotonView);
        Debug.Log("---10-------stream.IsWriting  " + stream.IsWriting);

        if (stream.IsWriting)
        {
            Debug.Log("##################### writingggggg");
            Debug.Log("##################### color.r" + color.r);
            Debug.Log("##################### color.g" + color.g);
            Debug.Log("##################### color.b" + color.b);
            stream.SendNext(color.r);
            stream.SendNext(color.g);
            stream.SendNext(color.b);
        }
        else
        {
            Debug.Log("##################### reading");
            Debug.Log("##################### color.r" + color.r);
            Debug.Log("##################### color.g" + color.g);
            Debug.Log("##################### color.b" + color.b);
            color.r = (float)stream.ReceiveNext();
            color.g = (float)stream.ReceiveNext();
            color.b = (float)stream.ReceiveNext();
        }

    }
}
