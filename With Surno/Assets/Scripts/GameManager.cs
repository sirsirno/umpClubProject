using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text talkText;
    public bool isAction = false;
    [SerializeField]
    private GameObject talkP;

    [SerializeField]
    private GameObject[] HWIn;  
    [SerializeField]
    private GameObject[] HWOut;


    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int stack = 0;

    private int lastRoom;

    private void Awake()
    {
        stack = 0;
        lastRoom = 4;
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
    public void Contact(RaycastHit scanObj)
    {
        if (scanObj.transform.CompareTag("Object"))
        {
            switch (scanObj.transform.name)
            {
                case "Capsule":
                    talkText.text = "이것은 캡슐";
                    break;
                case "Book":
                    talkText.text = "아무튼 책";
                    break;
                case "Door1In":
                    talkText.text = "문 1번IN";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                    player.transform.position = HWIn[0].transform.position;
                    lastRoom = 0;
                    break;
                case "Door2In":
                    talkText.text = "문 2번IN";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    player.transform.position = HWIn[1].transform.position;
                    lastRoom = 1;
                    break;
                case "Door3In":
                    talkText.text = "문 3번IN";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                    player.transform.position = HWIn[2].transform.position;
                    lastRoom = 2;
                    break;
                case "Door4In":
                    talkText.text = "문 4번IN";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    player.transform.position = HWIn[3].transform.position;
                    lastRoom = 3;
                    break;
                case "Door1Out":
                    talkText.text = "문 1번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, -180, 0);
                    player.transform.position = HWOut[0].transform.position;
                    lastRoom = 4;
                    break;
                case "Door2Out":
                    talkText.text = "문 2번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, -90, 0);
                    player.transform.position = HWOut[1].transform.position;
                    lastRoom = 4;
                    break;
                case "Door3Out":
                    talkText.text = "문 3번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    player.transform.position = HWOut[2].transform.position;
                    lastRoom = 4;
                    break;
                case "Door4Out":
                    talkText.text = "문 4번OUT";
                    player.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    player.transform.position = HWOut[3].transform.position;
                    lastRoom = 4;
                    break;
                case "DoorOut"://만약 잘못된 길에 들어갔을때
                    stack = 0;
                    switch (lastRoom)//마지막 통로에 따른 다른 출구위치와 플레이어 dir
                    {
                        case 0:
                            player.transform.localRotation = Quaternion.Euler(0, -180, 0);
                            player.transform.position = HWOut[0].transform.position;
                            break;
                        case 1:
                            player.transform.localRotation = Quaternion.Euler(0, -90, 0);
                            player.transform.position = HWOut[1].transform.position;
                            break;
                        case 2:
                            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                            player.transform.position = HWOut[2].transform.position;
                            break;
                        case 3:
                            player.transform.localRotation = Quaternion.Euler(0, 90, 0);
                            player.transform.position = HWOut[3].transform.position;
                            break;
                    }
                    break;
                    
            }
            StartCoroutine("Panel");
        }
        else
        {
            NotContact();
        }
    }
    private void NotContact()
    {
        Debug.Log("아무튼 아니야");

    }
    IEnumerator Panel()
    {
        talkP.SetActive(true);
        yield return new WaitForSeconds(1f);
        talkP.SetActive(false);
    }
}
