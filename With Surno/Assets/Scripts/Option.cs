using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Option
{
    [Header("사운드")]
    public float BGM;
    public float SFX;
    [Header("감도")]
    public float mouseSensitivity = 100;
}
