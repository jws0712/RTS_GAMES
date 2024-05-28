using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : GameObjectController
{
    private NavMeshAgent navMeshAgent = null; //���� ������Ʈ���� �ִ� ������Ʈ

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //������Ʈ�� ������
    }


    /// <summary>
    /// NavMesh�� ����ؼ� ���� ������Ʈ�� pos�� �̵���Ű�� �Լ�
    /// </summary>
    /// <param name="pos">������ ������</param>
    public void Move(Vector3 pos)
    {
        navMeshAgent.speed = 10f; //������ �ӵ�
        navMeshAgent.SetDestination(pos); //������ �������� ������
    }
}
