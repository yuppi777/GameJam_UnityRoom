using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody rb;

    private Vector3 moving, Pos;

    [SerializeField]
    private float speed;

    [SerializeField]
    [Header("���̊��x")]
    private float x_sensi;

    [SerializeField]
    [Header("�c�̊��x")]
    private float y_sensi;

    [SerializeField]
    private new GameObject camera;

    private void Awake()
    {
        OnInitialize();

    }
    void Start()
    {
        LookCus();
    }

    /// <summary>
    /// ������
    /// </summary>
    private void OnInitialize()
    {
        try
        {
          rb =  this.gameObject.GetComponent<Rigidbody>();
        }
        catch (System.Exception)
        {

            this.gameObject.AddComponent<Rigidbody>();
            rb = this.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void LookCus()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void MoveControll()
    {
        //moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //moving.Normalize();
        //moving *= speed;
        
    }
    /// <summary>
    /// �L�����N�^�[�̌������R���g���[��
    /// </summary>
    private void RotateControll()
    {
        Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(Pos.x, 0, Pos.z);
        Pos = transform.position;
        
        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
        {
            Quaternion rot = Quaternion.LookRotation(differenceDis);
            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
            this.transform.rotation = rot;
            //�A�j���[�V������ǉ�����ꍇ
            //animator.SetBool("run", true);
        }
        else
        {
            //animator.SetBool("run", false);
        }
    }

    private void Movement()
    {

        //if (Input.GetKey(KeyCode.W ))
        //{
        //    rb.AddForce(transform.forward * speed);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddForce(transform.right * -speed);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rb.AddForce(transform.forward * -speed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddForce(transform.right * speed);
        //}
        var tinpoV = Input.GetAxis("Vertical");
        var tinpoH = Input.GetAxis("Horizontal");
        moving = tinpoH * transform.right + tinpoV * transform.forward;
        rb.AddForce(moving * speed);

    }
  
    private void MoveCamera()
    {
        float x_Rotation = Input.GetAxis("Mouse X");
        float y_Rotation = Input.GetAxis("Mouse Y");
        x_Rotation = x_Rotation * x_sensi;
        y_Rotation = y_Rotation * y_sensi;
        this.transform.Rotate(0, x_Rotation, 0);
        camera.transform.Rotate(-y_Rotation, 0, 0);
    }
    void Update()
    {
        //MoveControll();
        Movement();
        MoveCamera();
    }
    private void FixedUpdate()
    {
        //RotateControll();
    }
}