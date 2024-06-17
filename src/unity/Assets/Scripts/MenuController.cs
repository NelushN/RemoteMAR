using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void OnClickModelPick(int whichModel)

    {
        if (ModelInfo.PI != null)
        {
            ModelInfo.PI.mySelectModel = whichModel;
            PlayerPrefs.SetInt("MyModel", whichModel);
        }

    }
}
