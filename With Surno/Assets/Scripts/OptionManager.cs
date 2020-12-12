using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    static GameObject _container;

    static OptionManager _instance;
    public static OptionManager Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "OptionManager";
                _instance = _container.AddComponent(typeof(OptionManager)) as OptionManager;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    public Option _option;

}
