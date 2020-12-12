using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyForFirstScene : MonoBehaviour
{
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (transform.position.z > 35 || transform.position.z < -35 || transform.position.x > 35 || transform.position.x < -35)
            transform.position = startPosition;
    }
}
