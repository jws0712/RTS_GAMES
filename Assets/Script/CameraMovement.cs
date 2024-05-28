using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("CameraMoveInfo")]
    [SerializeField] private float nomalSpeed = default;
    [SerializeField] private float shiftSpeed = default;

    [Header("WorldBord")]
    [SerializeField] private Transform minPos = null;
    [SerializeField] private Transform maxPos = null;

    private float speed = default;
    private Vector3 Dir = Vector3.zero;

    private void Update()
    {
        PlayerInput();
        CameraMove();
    }

    private void LateUpdate()
    {
        WorldBord();
    }

    /// <summary>
    /// 플레이어의 입력을 받아 처리하는 함수
    /// </summary>
    private void PlayerInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Dir = new Vector3(x, 0f, z); //방향을 만듬

        //쉬프트를 눌렀을때만 더 빠르게 움직이게 함
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = shiftSpeed;
        }
        else
        {
            speed = nomalSpeed;
        }
    }

    /// <summary>
    /// 방향을 받아서 카메라를 움직이는 함수
    /// </summary>
    private void CameraMove()
    {
        transform.Translate(Dir * speed * Time.deltaTime); //카메라 움직임
    }

    /// <summary>
    /// 카메라 이동의 제한을 두는 월드보드를 만드는 함수
    /// </summary>
    private void WorldBord()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;

        //카메라의 트랜스폼값을 특정 범위 내에서만 움직이게함
        posX = Mathf.Clamp(transform.position.x, minPos.position.x, maxPos.position.x); 
        posZ = Mathf.Clamp(transform.position.z, minPos.position.z, maxPos.position.z); 

        transform.position = new Vector3(posX, transform.position.y, posZ); 
    }
}
