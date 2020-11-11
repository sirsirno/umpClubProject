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
                talkText.text = "아무튼 책임";
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
