using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject TechDropdown;
    [SerializeField] GameObject TechSubmitBtn;
    [SerializeField] GameObject ExitBtn;
    // Start is called before the first frame update

    public void TechSelect()
    {
        int val = TechDropdown.GetComponent<TMP_Dropdown>().value;
        // TODO: set custom properties for model selection
        switch (val)
        {
            case 0:
                SelectAllSyncNonStream();
                break;

            case 1:
                SelectNonStream();
                break;

            case 2:
                SelectNonStreamNonSync();
                break;

            case 3:
                SelectStreamSync();
                break;

            case 4:
                SelectStreamNonSync();
                break;
        }
    }

    public void SelectNonStream()
    {
        SceneManager.LoadScene("NonStream");
    }
    public void SelectNonStreamNonSync()
    {
        SceneManager.LoadScene("NonStreamNonSync");
    }
    public void SelectStreamSync()
    {
        SceneManager.LoadScene("StreamSync");
    }
    public void SelectStreamNonSync()
    {
        SceneManager.LoadScene("StreamNonSync");
    }
    public void SelectAllSyncNonStream()
    {
        SceneManager.LoadScene("AllSyncNonStream");
    }
    public void exit()
    {
        Application.Quit();
    }
}
