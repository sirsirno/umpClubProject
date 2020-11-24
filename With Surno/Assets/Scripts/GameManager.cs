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
    private GameObject RP1;
    [SerializeField]
    private GameObject RP2;
    [SerializeField]
    private GameObject RP3;
    [SerializeField]
    private GameObject RP4;

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
            if (scanObj.transform.name == "Door1")
            {
                talkText.text = "문 1번";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                player.transform.position = RP1.transform.position;
            }
            if (scanObj.transform.name == "Door2")
            {
                talkText.text = "문 2번";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.position = RP2.transform.position;

            }
            if (scanObj.transform.name == "Door3")
            {
                talkText.text = "문 3번";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0); ;
                player.transform.position = RP3.transform.position;

            }
            if (scanObj.transform.name == "Door4")
            {
                talkText.text = "문 4번";
                player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                player.transform.position = RP4.transform.position;

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
