using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData
{
    [Header("스택")]
    public int stack = 0;
    [Header("오프닝 봤냐 안봤냐")]
    public bool isOpening = false;
    [Header("사운드")]
    public float BGM;
    public float SFX;
    [Header("감도")]
    public float mouseSensitivity = 100;
    public float sensitivityOnUi = 0;
}
