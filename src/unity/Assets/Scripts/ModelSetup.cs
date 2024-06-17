using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ModelSetup : MonoBehaviour
{
    private PhotonView PV;
    public int modelValue;
    public GameObject myModel;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddModel", RpcTarget.AllBuffered, ModelInfo.PI.mySelectModel);
        }
    }

    [PunRPC]
    void RPC_AddModel(int whichModel)
    {
        modelValue = whichModel;
        myModel = Instantiate(ModelInfo.PI.allModels[whichModel], transform.position, transform.rotation, transform);
    }
}
