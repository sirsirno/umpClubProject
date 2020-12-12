using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpAc : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOptionOn)
            {
                OptionOff();
                isOptionOn = false;
            }
            else
            {
                OptionOn();
                isOptionOn = true;
            }
        }
    }
    static public bool isOptionOn = false;
    public void OptionOn()
    {
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
        Cursor.lockState = CursorLockMode.None;
    }
    public void OptionOff()
    {
        SceneManager.UnloadSceneAsync("Option");
        Cursor.lockState = CursorLockMode.Locked;

    }
}
