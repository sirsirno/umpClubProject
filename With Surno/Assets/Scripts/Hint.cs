using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    double fadeDeltaTime = 0; 
    private bool isFadeIn = false;

    public AudioSource p_Hint;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        p_Hint = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isReset== false)
        {
            if (isFadeIn)
            {
                fadeDeltaTime += Time.deltaTime;
                if (fadeDeltaTime >= 1)
                {
                    fadeDeltaTime = 1;
                }
                p_Hint.volume = (float)(fadeDeltaTime / 1);
            }
            else
            {
                fadeDeltaTime -= Time.deltaTime;
                if (fadeDeltaTime <= 0)
                {
                    fadeDeltaTime = 0;
                }
                p_Hint.volume = (float)(fadeDeltaTime);
            }
        }
        else
        {
            p_Hint.volume = 0;
        }
       

    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "P_Hint")
        {
            isFadeIn = true;
            p_Hint.Play();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(collider.name == "P_Hint")
        {
            isFadeIn = false;
            Invoke("P_HintStop", 10);
        }

    }
    private void P_HintStop()
    {
        p_Hint.Stop();
    }
}
