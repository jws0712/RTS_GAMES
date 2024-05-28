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
    /// �÷��̾��� �Է��� �޾� ó���ϴ� �Լ�
    /// </summary>
    private void PlayerInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Dir = new Vector3(x, 0f, z); //������ ����

        //����Ʈ�� ���������� �� ������ �����̰� ��
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
    /// ������ �޾Ƽ� ī�޶� �����̴� �Լ�
    /// </summary>
    private void CameraMove()
    {
        transform.Translate(Dir * speed * Time.deltaTime); //ī�޶� ������
    }

    /// <summary>
    /// ī�޶� �̵��� ������ �δ� ���庸�带 ����� �Լ�
    /// </summary>
    private void WorldBord()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;

        //ī�޶��� Ʈ���������� Ư�� ���� �������� �����̰���
        posX = Mathf.Clamp(transform.position.x, minPos.position.x, maxPos.position.x); 
        posZ = Mathf.Clamp(transform.position.z, minPos.position.z, maxPos.position.z); 

        transform.position = new Vector3(posX, transform.position.y, posZ); 
    }
}
