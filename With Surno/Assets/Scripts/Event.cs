using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FirstjumpScare;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Door")
        {
            StartCoroutine(Scare());
            player.isSlow = true;
            SaveGame.Instance._gameData.mouseSensitivity -= 90;
        }
    }

    private IEnumerator Scare()
    {
        FirstjumpScare[0].SetActive(false);
        yield return new WaitForSeconds(2f);
        FirstjumpScare[1].SetActive(true);
        yield return new WaitForSeconds(.5f);
        FirstjumpScare[1].SetActive(false);
        yield return new WaitForSeconds(.2f);
        FirstjumpScare[2].SetActive(true);
        yield return new WaitForSeconds(.2f);
        FirstjumpScare[2].SetActive(false);
        FirstjumpScare[3].SetActive(true);
        yield return new WaitForSeconds(.2f);
        player.isSlow = false;
        SaveGame.Instance._gameData.mouseSensitivity += 90;
        LoadingSceneController.LoadScene("inGameScene");
    }
}
