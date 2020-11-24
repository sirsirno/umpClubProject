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

    private void Awake()
    {
        stack = 0;
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
            if(scanObj.transform.name == "Capsule")
            {
                talkText.text = "이것은 캡슐";
            }
            if(scanObj.transform.name == "Book")
            {
                talkText.text = "아무튼 책";
            }
            if (scanObj.transform.name == "Door1In")
            {
                talkText.text = "문 1번IN";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                player.transform.position = HWIn[0].transform.position;
            }
            if (scanObj.transform.name == "Door2In")
            {
                talkText.text = "문 2번IN";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.position = HWIn[1].transform.position;

            }
            if (scanObj.transform.name == "Door3In")
            {
                talkText.text = "문 3번IN";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                player.transform.position = HWIn[2].transform.position;

            }
            if (scanObj.transform.name == "Door4In")
            {
                talkText.text = "문 4번IN";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.position = HWIn[3].transform.position;

            }
            if(scanObj.transform.name == "Door1Out")
            {
                talkText.text = "문 1번OUT";
                player.transform.localRotation = Quaternion.Euler(0, -180, 0);
                player.transform.position = HWOut[0].transform.position;
            }
            if (scanObj.transform.name == "Door2Out")
            {
                talkText.text = "문 2번OUT";
                player.transform.localRotation = Quaternion.Euler(0, -90, 0);
                player.transform.position = HWOut[1].transform.position;
            }
            if (scanObj.transform.name == "Door3Out")
            {
                talkText.text = "문 3번OUT";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.position = HWOut[2].transform.position;
            }
            if (scanObj.transform.name == "Door4Out")
            {
                talkText.text = "문 4번OUT";
                player.transform.localRotation = Quaternion.Euler(0, 90, 0);
                player.transform.position = HWOut[3].transform.position;
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
