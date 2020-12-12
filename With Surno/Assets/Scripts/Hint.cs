using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public static Hint instance;

    public GameObject HintSound;

    public void HintSoundOn()
    {
        if (HintSound.activeSelf)
            HintSound.SetActive(false);
        else
            HintSound.SetActive(true);
    }
}
