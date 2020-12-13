using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Text talkText;
    public bool isAction = false;
    [SerializeField]
    private GameObject talkP;

    [SerializeField]
    private Transform[] HWIn;  
    [SerializeField]
    private Transform[] HWOut;
    [SerializeField]
    private Transform wrongWay;

    [SerializeField]
    private GameObject player;

    [SerializeField] 
    private GameObject HintSound;


    private int lastRoom;
    [SerializeField]
    private GameObject tvHint;

    public bool isReset;
    private void Awake()
    {
        SaveGame.Instance.gameData.stack = 0;
        lastRoom = 4;
    }
    private void Start()
    {
        StartCoroutine(StartEvent());
    }
    public void ReAction()
    {
        if (isAction)//exit Action
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            
        }
       
    }
    #region Contact
    public void Contact(RaycastHit scanObj)
    {
        if (scanObj.transform.CompareTag("Object"))
        {
            switch (scanObj.transform.name)
            {
                case "Capsule":
                    talkText.text = "이것은 캡슐";
                    break;
                case "BookShelf":
                    talkText.text = "비어있는 책장이다...";
                    break;
                case "Book":
                    talkText.text = "아무것도 적혀있지않다...";
                    break;
                case "Door1In":
                    talkText.text = "문 1번IN";//서순 = 3-4-2-1
                    if (SaveGame.Instance.gameData.stack == 3)
                    {
                        player.transform.position = HWIn[0].position;
                        SaveGame.Instance.gameData.stack++;
                    }
                    else
                    {
                        player.transform.position = wrongWay.position;
                        SaveGame.Instance.gameData.stack = 0;
                        ResetStage();
                    }
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                    lastRoom = 0;
                    break;
                case "Door2In":
                    talkText.text = "문 2번IN";
                    if(SaveGame.Instance.gameData.stack == 2)
                    {
                        player.transform.position = HWIn[1].position;
                        SaveGame.Instance.gameData.stack++;
                    }
                    else
                    {
                        player.transform.position = wrongWay.position;
                        SaveGame.Instance.gameData.stack = 0;
                        ResetStage();
                    }
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    lastRoom = 1;
                    break;
                case "Door3In":
                    talkText.text = "문 3번IN";
                    if(SaveGame.Instance.gameData.stack == 0)
                    {
                        player.transform.position = HWIn[2].position;
                        SaveGame.Instance.gameData.stack++;
                        ResetStage();
                        tvHint.SetActive(true);
                    }
                    else
                    {
                        player.transform.position = wrongWay.position;
                        SaveGame.Instance.gameData.stack = 0;
                        ResetStage();
                    }
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                    lastRoom = 2;
                    break;
                case "Door4In":
                    talkText.text = "문 4번IN";
                    if(SaveGame.Instance.gameData.stack == 1)
                    {
                        player.transform.position = HWIn[3].position;
                        SaveGame.Instance.gameData.stack++;
                        tvHint.SetActive(false);
                    }
                    else
                    {
                        player.transform.position = wrongWay.position;
                        SaveGame.Instance.gameData.stack = 0;
                        ResetStage();
                    }
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    lastRoom = 3;
                    break;
                case "Door1Out":
                    talkText.text = "문 1번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, -180, 0);
                    player.transform.position = HWOut[0].position;
                    lastRoom = 4;
                    break;
                case "Door2Out":
                    talkText.text = "문 2번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    player.transform.position = HWOut[1].position;
                    lastRoom = 4;
                    break;
                case "Door3Out":
                    talkText.text = "문 3번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    player.transform.position = HWOut[2].position;
                    lastRoom = 4;
                    break;
                case "Door4Out":
                    talkText.text = "문 4번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    player.transform.position = HWOut[3].position;
                    lastRoom = 4;
                    break;
                case "DoorOut"://만약 잘못된 길에 들어갔을때
                    SaveGame.Instance.gameData.stack = 0;
                    switch (lastRoom)//마지막 통로에 따른 다른 출구위치와 플레이어 dir
                    {
                        case 0:
                            player.transform.localRotation = Quaternion.Euler(0, -180, 0);
                            player.transform.position = HWOut[0].position;
                            break;
                        case 1:
                            player.transform.localRotation = Quaternion.Euler(0, -90, 0);
                            player.transform.position = HWOut[1].position;
                            break;
                        case 2:
                            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            player.transform.position = HWOut[2].position;
                            break;
                        case 3:
                            player.transform.localRotation = Quaternion.Euler(0, 90, 0);
                            player.transform.position = HWOut[3].position;
                            break;
                    }
                    break;
                    
            }
            talkP.SetActive(true);
            Invoke("PanelOff",2);
        }
        else
        {
            NotContact();
        }
    }
    #endregion

    public void HintSoundOn()
    {
        if (HintSound.activeSelf)
            HintSound.SetActive(false);
        else
            HintSound.SetActive(true);
    }
    private void ResetStage()
    {
        HintSoundOn();
        tvHint.SetActive(false);
    }
    private void NotContact()
    {
        Debug.Log("아무튼 아니야");

    }
    private void PanelOff()
    {
        talkP.SetActive(false);
    }
    private IEnumerator StartEvent()
    {
        talkP.SetActive(true);
        talkText.text = "머리가 깨질듯 하다...";
        yield return new WaitForSeconds(3);

        talkP.SetActive(true);
        talkText.text = "왜 이곳에 왔는지 모르겠다...";
        yield return new WaitForSeconds(2);

        talkP.SetActive(true);
        talkText.text = "이곳을 탈출 해야 할 것 같다";
        yield return new WaitForSeconds(3);

        talkP.SetActive(true);
        talkText.text = "일단 정보들을 찾아보자";
        yield return new WaitForSeconds(3);
        talkP.SetActive(false);
    }
}
