using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FirstjumpScare;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartEvent();
    }
    public void StartEvent()
    {
        StartCoroutine(Scare());
    }

    private IEnumerator Scare()
    {
        FirstjumpScare[0].SetActive(false);
        yield return new WaitForSeconds(.1f);
        FirstjumpScare[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        FirstjumpScare[1].SetActive(false);
        yield return new WaitForSeconds(.1f);
        FirstjumpScare[2].SetActive(true);
        yield return new WaitForSeconds(.1f);
        FirstjumpScare[2].SetActive(false);
        FirstjumpScare[3].SetActive(true);
    }
}
