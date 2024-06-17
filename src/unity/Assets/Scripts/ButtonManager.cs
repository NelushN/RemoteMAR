using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // translating 
    Lean.Touch.LeanTranslate modelTranslateScript;
    // scaling
    Lean.Touch.LeanScale modelScaleScript;
    // rotation 
    //Lean.Touch.LeanRotateCustomAxisX modelRotateXScript;
    //Lean.Touch.LeanRotateCustomAxisY modelRotateYScript;
    //Lean.Touch.LeanRotateCustomAxisZ modelRotateZScript;
    // model outer shell + label
    GameObject shell;
    [SerializeField] GameObject shellLbl;
    [SerializeField] GameObject shellActiveSprite;
    [SerializeField] GameObject shellInactiveSprite;
    BoxCollider shellColl;
    // annotation panel, annotate texts + input 
    List<GameObject> texts = new List<GameObject>();
    [SerializeField] GameObject annotationInputText;
    private int textsCounter = 0;
    [SerializeField] GameObject helpBtn;
    [SerializeField] GameObject helpPnl;
    // panel displayed after cancer nodule is selected
    [SerializeField] GameObject nodulePnl;
    // label used for each model (kidney or lungs)
    [SerializeField] GameObject modeLbl;
    // models
    [SerializeField] GameObject lungs;
    [SerializeField] GameObject kidneys;
    [SerializeField] GameObject cube1;
    [SerializeField] GameObject cube2;
    [SerializeField] GameObject city1;
    [SerializeField] GameObject city2;
    [SerializeField] GameObject cube3;
    [SerializeField] GameObject cube4;
    [SerializeField] GameObject city3;
    [SerializeField] GameObject city4;
    // initial screen mode selection variable 
    [SerializeField] GameObject modelSelectPnl;
    // axis status based on number of taps
    string axisStatus = "";
    [SerializeField] GameObject modeImage;
    public Sprite xImage;
    public Sprite yImage;
    public Sprite zImage;
    // dropdown object for model selection
    public GameObject modelDropdown;
    // Used for the 1-click annotations (circle, arrow) to act as the anchor object
    public GameObject centralObject;
    // Hashtable to store what model is being used and any other custom properties


    // gets dropdown value and displays the appropriate model
    public void ModelSelect()
    {
        int val = modelDropdown.GetComponent<TMP_Dropdown>().value;
        // TODO: set custom properties for model selection
        PhotonNetwork.CurrentRoom.CustomProperties["model"] = val;
        switch (val)
        {

            case 0:
                SelectCube1();
                break;

            case 1:
                SelectCube2();
                break;

            case 2:
                SelectCity1();
                break;

            case 3:
                SelectCity2();
                break;

            case 4:
                SelectCube3();
                break;

            case 5:
                SelectCube4();
                break;

            case 6:
                SelectCity3();
                break;

            case 7:
                SelectCity4();
                break;
        }
    }

    // displays lungs when selected
    public void SelectLungs()
    {
        lungs.SetActive(true);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            lungs = PhotonNetwork.Instantiate("models/model", lungs.transform.position, lungs.transform.rotation, 0);
            centralObject = GameObject.Find("ImageTarget/model/model/default");
        }
        Setup();
    }

    // displays kidneys when selected
    public void SelectKidneys()
    {
        lungs.SetActive(false);
        kidneys.SetActive(true);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            kidneys = PhotonNetwork.Instantiate("models/model2", kidneys.transform.position, kidneys.transform.rotation, 0);
            centralObject = GameObject.Find("ImageTarget/model2/model/default");
        }
        Setup();
    }

    // displays cube when selected
    public void SelectCube1()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(true);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            cube1 = PhotonNetwork.Instantiate("models/model4", cube1.transform.position, cube1.transform.rotation, 0);
            Destroy(cube1);
            centralObject = GameObject.Find("ImageTarget/model4");
        }
        Setup();
    }
    public void SelectCube2()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(true);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            cube2 = PhotonNetwork.Instantiate("models/modelc5", cube2.transform.position, cube2.transform.rotation, 0);
            Destroy(cube2);
            centralObject = GameObject.Find("ImageTarget/modelc5");
        }
        Setup();
    }
    public void SelectCity1()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(true);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            city1 = PhotonNetwork.Instantiate("models/modelc10", city1.transform.position, city1.transform.rotation, 0);
            Destroy(city1);
            centralObject = GameObject.Find("ImageTarget/modelc10");
        }
        Setup();
    }
    public void SelectCity2()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(true);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            city2 = PhotonNetwork.Instantiate("models/model7", city2.transform.position, city2.transform.rotation, 0);
            Destroy(city2);
            centralObject = GameObject.Find("ImageTarget/model7");
        }
        Setup();
    }

    // displays cube when selected
    public void SelectCube3()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(true);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            cube3 = PhotonNetwork.Instantiate("models/model8", cube3.transform.position, cube3.transform.rotation, 0);
            Destroy(cube3);
            centralObject = GameObject.Find("ImageTarget/model8");
        }
        Setup();
    }
    public void SelectCube4()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(true);
        city3.SetActive(false);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            cube4 = PhotonNetwork.Instantiate("models/model11", cube4.transform.position, cube4.transform.rotation, 0);
            Destroy(cube4);
            centralObject = GameObject.Find("ImageTarget/model11");
        }
        Setup();
    }
    public void SelectCity3()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(true);
        city4.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            city3 = PhotonNetwork.Instantiate("models/model9", city3.transform.position, city3.transform.rotation, 0);
            Destroy(city3);
            centralObject = GameObject.Find("ImageTarget/model9");
        }
        Setup();
    }
    public void SelectCity4()
    {
        lungs.SetActive(false);
        kidneys.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        city1.SetActive(false);
        city2.SetActive(false);
        cube3.SetActive(false);
        cube4.SetActive(false);
        city3.SetActive(false);
        city4.SetActive(true);

        if (PhotonNetwork.IsConnected)
        {
            city4 = PhotonNetwork.Instantiate("models/model6", city4.transform.position, city4.transform.rotation, 0);
            Destroy(city4);
            centralObject = GameObject.Find("ImageTarget/model6");
        }
        Setup();
    }
    // functions is called on initial load
    private void Setup()
    {
        // initialize game objects based on their tags
        modelTranslateScript = GameObject.FindWithTag("model").GetComponent<Lean.Touch.LeanTranslate>();
        modelScaleScript = GameObject.FindWithTag("model").GetComponent<Lean.Touch.LeanScale>();
        //modelRotateXScript = GameObject.FindWithTag("model").GetComponent<Lean.Touch.LeanRotateCustomAxisX>();
        //modelRotateYScript = GameObject.FindWithTag("model").GetComponent<Lean.Touch.LeanRotateCustomAxisY>();
        //modelRotateZScript = GameObject.FindWithTag("model").GetComponent<Lean.Touch.LeanRotateCustomAxisZ>();
        shell = GameObject.FindWithTag("model");
        shellColl = GameObject.FindWithTag("model").GetComponent<BoxCollider>();

        modelSelectPnl.SetActive(false);
        helpPnl.SetActive(true);
        // detect finger tap         
        Lean.Touch.LeanTouch.OnFingerTap += HandleFingerTap;


        // initial state of the model
        modelTranslateScript.enabled = true;
        modelScaleScript.enabled = true;
        //modelRotateXScript.enabled = true;
        //modelRotateYScript.enabled = false;
        //modelRotateZScript.enabled = false;
        axisStatus = "X Axis";
    }

    void Update()
    {
        modeImage.SetActive(!Annotate.isAnnotateActive);
    }


    // function is called onDisable 
    void OnDisable()
    {
        Lean.Touch.LeanTouch.OnFingerTap -= HandleFingerTap;
    }


    // function to handle finger taps from user
    void HandleFingerTap(Lean.Touch.LeanFinger finger)
    {
        var fingerTapCount = finger.TapCount;

        // only allow scaling, translating and rotating if annotate is inactive
        if (!Annotate.isAnnotateActive)
        {
            // actions based on number of user finger taps
            switch (fingerTapCount)
            {
                // x axis 
                case 1:
                    modelTranslateScript.enabled = true;
                    modelScaleScript.enabled = true;
                    //modelRotateXScript.enabled = true;
                    //modelRotateYScript.enabled = false;
                    //modelRotateZScript.enabled = false;
                    modeImage.GetComponent<Image>().sprite = xImage;
                    break;
                // y axis 
                case 2:
                    modelTranslateScript.enabled = false;
                    modelScaleScript.enabled = false;
                    //modelRotateXScript.enabled = false;
                    //modelRotateYScript.enabled = true;
                    //modelRotateZScript.enabled = false;
                    modeImage.GetComponent<Image>().sprite = yImage;
                    break;
                // z axis
                case 3:
                    modelTranslateScript.enabled = false;
                    modelScaleScript.enabled = false;
                    //modelRotateXScript.enabled = false;
                    //modelRotateYScript.enabled = false;
                    //modelRotateZScript.enabled = true;
                    modeImage.GetComponent<Image>().sprite = zImage;
                    break;
            }
        }
        // disable all model attributes when annotating is active
        else
        {
            modelTranslateScript.enabled = false;
            modelScaleScript.enabled = false;
            //modelRotateXScript.enabled = false;
            //modelRotateYScript.enabled = false;
            //modelRotateZScript.enabled = false;
        }

        // TODO: Look into making this "less" expensive and refactoring it 
        modeLbl.GetComponent<TMPro.TextMeshProUGUI>().text = axisStatus;
        // TODO: stop following line from  creating an ArgumentOutOfRange exception
        texts[textsCounter == 0 ? textsCounter : textsCounter - 1].GetComponent<Lean.Touch.LeanTranslate>().enabled =
            false;
        texts[textsCounter == 0 ? textsCounter : textsCounter - 1].GetComponent<Lean.Touch.LeanScale>().enabled = false;
    }

    // function is called to hide/show shell depending on the current state of shell
    public void Shell()
    {
        if (shell.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled)
        {
            shell.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            shellActiveSprite.SetActive(true);
            shellInactiveSprite.SetActive(false);
        }
        else
        {
            shell.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            shellActiveSprite.SetActive(false);
            shellInactiveSprite.SetActive(true);
        }

        UpdateShellButtonLabel();
    }

    private void UpdateShellButtonLabel()
    {
        /** shellLbl.GetComponent<TMPro.TextMeshProUGUI>().text =
            (shell.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled)
                ? "Show shell"
                : "Hide shell"; **/
        /** if (shell.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled)
        {
            shellActiveSprite.SetActive(true);
            shellInactiveSprite.SetActive(false);
        }
        else
        {
            shellActiveSprite.SetActive(false);
            shellInactiveSprite.SetActive(true);
        } **/
    }

    // function is called after user preses "OK" after viewing the cancer nodule
    public void DoneWithNodule()
    {
        nodulePnl.SetActive(false);
    }

    public void DisplayHelp()
    {
        bool isHelpActive = helpPnl.activeSelf;
        helpPnl.SetActive(!isHelpActive);
        helpBtn.SetActive(isHelpActive);
        UpdateShellButtonLabel();
    }
    public void onClick_ExitButton()
    {
        //if (PhotonNetwork.InRoom)
        //{
        //    Leave the current room
        //    PhotonNetwork.LeaveRoom();
        //}
        SceneManager.LoadScene("Menu");

    }

}