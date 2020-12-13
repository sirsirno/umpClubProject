using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject secPanel;

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
    public void ItisOption()
    {
        OpAc.isStartScene = true;
    }
    public void OptionOff()
    {
        SceneManager.UnloadSceneAsync("Option");

        if (OpAc.isStartScene == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            SaveGame.Instance._gameData.mouseSensitivity = SaveGame.Instance._gameData.sensitivityOnUi;
            SaveGame.Instance._gameData.sensitivityOnUi = 0;
            OpAc.isOptionOn = false;
        }

    }
    public void ReallyExit()
    {
        if (secPanel != null)
        {
            if (secPanel.activeSelf)
                secPanel.SetActive(false);
            else
                secPanel.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
