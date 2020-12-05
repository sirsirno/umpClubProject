using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float moveSpeed = 1.0f;
    [SerializeField]
    private float runSpeed = 1.5f;

    private float stamina = 100f;
    private float maxStamina;

    private bool isRun = false;

    Rigidbody rigid = null;
    [SerializeField]
    private GameManager manager;

    private GameObject scanObject;

    private RaycastHit actionInfo;

    [SerializeField]
    private Camera theCam;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        maxStamina = stamina;
    }

    private void Update()
    {
        Action();
    }
    private void FixedUpdate()
    {
        Move();
        Run();
    }

    private void Move()
    {
        //이동
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Vertical") < 0)
            moveVelocity = transform.TransformDirection(Vector3.back);
        else if (Input.GetAxisRaw("Vertical") > 0)
            moveVelocity = transform.TransformDirection(Vector3.forward);
        if (Input.GetAxisRaw("Horizontal") < 0)
            moveVelocity = transform.TransformDirection(Vector3.left);
        else if (Input.GetAxisRaw("Horizontal") > 0)
            moveVelocity = transform.TransformDirection(Vector3.right);
        transform.position += moveVelocity * speed * Time.deltaTime;
       
    }
    private void Run()
    {
        //달리기
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            speed = runSpeed;
            isRun = true;
            stamina--;
        }
        if (stamina < maxStamina && isRun == false)
            stamina += .5f;
        if (!Input.GetKey(KeyCode.LeftShift) || stamina <= 0)
        {
            isRun = false;
            speed = moveSpeed;
        }
        stamina += 0.1f * Time.deltaTime;
    }
    private void RayCast()
    {
        //Ray
        Debug.DrawRay(theCam.transform.position, theCam.transform.forward, new Color(0, 1, 0));
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward, out actionInfo, 2))
        {
            manager.Contact(actionInfo);
        }
    }
    private void Action()
    {
        //상호작용
        if(Input.GetKeyDown(KeyCode.E))
        {
            RayCast();
            manager.ReAction();
        }
    }
}
