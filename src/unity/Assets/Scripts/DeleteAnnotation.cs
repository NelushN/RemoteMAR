using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using UnityEngine.UI;
using Photon.Pun;

public class DeleteAnnotation : MonoBehaviour
{
    public Toggle deleteBtn;
    public static bool deleteEnabled = false;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (deleteEnabled && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                print(hit.collider);
                if (hit.collider.gameObject.tag == "annotation")
                {
                    Debug.Log("Hit Annotation");
                    PhotonView view = PhotonView.Find(hit.collider.gameObject.GetPhotonView().ViewID);
                    //any new annotation prefabs added must have the "annotation" tag added to them in the inspector 
                    DeleteOneAnnotation(hit.collider.gameObject);
                }
            }
        }
    }

    public void DeleteOneAnnotation(GameObject obj)
    {
        Photon.Pun.PhotonNetwork.Destroy(obj);
        print(obj.name + " destroyed!");
    }

    public void onClick_Delete()
    {
        // deleteEnabled = !deleteEnabled;
        deleteEnabled = deleteBtn.isOn;
        GameObject[] btns = GameObject.FindGameObjectsWithTag("btn");
        if (deleteEnabled)
        {
            print("delete enabled!");
            toggleBtnVisibility(btns, false);
        }
        else
        {
            print("delete disabled!");
            toggleBtnVisibility(btns, true);
        }
    }

    public void toggleBtnVisibility(GameObject[] btns, bool toggle)
    {
        foreach (GameObject btn in btns)
        {
            if (btn.name == "DeleteToggle")
            {
                continue;
            }
            btn.GetComponent<Selectable>().interactable = toggle;
        }
    }

}
