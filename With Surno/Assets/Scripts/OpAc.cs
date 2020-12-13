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
    static public bool isStartScene = false;
    public void OptionOn()
    {
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
        Cursor.lockState = CursorLockMode.None;
        SaveGame.Instance._gameData.sensitivityOnUi = SaveGame.Instance._gameData.mouseSensitivity;
        SaveGame.Instance._gameData.mouseSensitivity = 0;
    }
    public void OptionOff()
    {
        SceneManager.UnloadSceneAsync("Option");
        Cursor.lockState = CursorLockMode.Locked;
        SaveGame.Instance._gameData.mouseSensitivity = SaveGame.Instance._gameData.sensitivityOnUi;
        SaveGame.Instance._gameData.sensitivityOnUi = 0;
    }
}
