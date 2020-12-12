using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public void GameStart()
    {
        if (!SaveGame.Instance.gameData.isOpening)
            LoadingSceneController.LoadScene("FirstScene");
        else
            LoadingSceneController.LoadScene("inGameScene");
    }

    public void OptionOn()
    {
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    }
    public void OptionOff()
    {
        SceneManager.UnloadSceneAsync("Option");
        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
        OpAc.isOptionOn = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
