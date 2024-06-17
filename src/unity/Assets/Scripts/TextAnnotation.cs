using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class TextAnnotation : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject ButtonManager;
    private bool addTextEnabled = false;
    private GameObject textAnnotation;

    public GameObject TextAnnotationPnl;
    private string textAnnotationText;
    public Toggle TextAnnotationToggle;

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (addTextEnabled && Input.GetMouseButtonDown(0))
        {
            addTextEnabled = false;
            TextAnnotationToggle.isOn = false;
            TextAnnotationPnl.SetActive(false);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            BoxCollider mc = ButtonManager.GetComponent<ButtonManager>().centralObject.GetComponent<BoxCollider>();
            if (!mc.Raycast(ray, out hit, 1000))
            {
                return;
            }
            Vector3 hitVector = hit.point;
            int val = ButtonManager.GetComponent<ButtonManager>().modelDropdown.GetComponent<TMP_Dropdown>().value;
            addTextEnabled = false;
            if (val == 0) // Cube1, 2 for modelKey in AddTextLabel
            {
                AddTextLabel(3, hitVector, hit, textAnnotationText);
            }
            else if (val == 1) // Cube2, 4 for modelKey AddTextLabel
            {
                AddTextLabel(4, hitVector, hit, textAnnotationText);
            }

            else if (val == 2) // City1, 7 for modelKey AddTextLabel
            {
                AddTextLabel(6, hitVector, hit, textAnnotationText);
            }

            else if (val == 3) // City2, 5 for modelKey AddTextLabel
            {
                AddTextLabel(5, hitVector, hit, textAnnotationText);
            }
        }
    }

    public void AddTextLabel(int modelKey, Vector3 hitVector, RaycastHit hit, string inputText)
    {
        PhotonView view = PhotonView.Find(modelKey);
        textAnnotation = PhotonNetwork.Instantiate(text.name, hitVector, Quaternion.FromToRotation(Vector3.back, hit.normal));
        textAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
        textAnnotation.GetComponentInChildren<TextMeshPro>().text = inputText;
        view.RPC("AddTextLabelRPC", RpcTarget.Others, textAnnotation.GetPhotonView().ViewID, inputText);
    }

    [PunRPC]
    public void AddTextLabelRPC(int viewID, string inputText)
    {
        textAnnotation = PhotonView.Find(viewID).gameObject;
        textAnnotation.GetComponentInChildren<TextMeshPro>().text = inputText;
        textAnnotation.transform.SetParent(ButtonManager.GetComponent<ButtonManager>().centralObject.transform);
    }

    public void onClick_AddText()
    {
        TextAnnotationPnl.SetActive(!TextAnnotationPnl.activeSelf);
    }

    public void onClick_TextSubmit()
    {
        textAnnotationText = TextAnnotationPnl.GetComponentInChildren<TMP_InputField>().text;
        TextAnnotationPnl.SetActive(!TextAnnotationPnl.activeSelf);
        TextAnnotationPnl.GetComponentInChildren<TMP_InputField>().text = "";
        addTextEnabled = true;
    }
}
