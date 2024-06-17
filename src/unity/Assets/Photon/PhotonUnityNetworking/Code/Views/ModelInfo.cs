using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInfo : MonoBehaviour
{
    public static ModelInfo PI;
    public int mySelectModel;
    public GameObject[] allModels;

    private void OnEnable()
    {
        if(ModelInfo.PI == null)
        {
            ModelInfo.PI = this;
        }
        else 
        {
         if (ModelInfo.PI != this)
            {
                Destroy(ModelInfo.PI.gameObject);
                ModelInfo.PI = this;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("MyModel"))
        {
            mySelectModel = PlayerPrefs.GetInt("MyModel");
        }
        else {
            mySelectModel = 0;
            PlayerPrefs.SetInt("MyModel", mySelectModel);
        }
    }

}
