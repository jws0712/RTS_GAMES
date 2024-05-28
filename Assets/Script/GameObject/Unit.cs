using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : GameObjectController
{
    private NavMeshAgent navMeshAgent = null; //유닛 오브젝트내에 있는 에이전트

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //에이전트를 가져옴
    }


    /// <summary>
    /// NavMesh를 사용해서 유닛 오브젝트를 pos로 이동시키는 함수
    /// </summary>
    /// <param name="pos">유닛의 목적지</param>
    public void Move(Vector3 pos)
    {
        navMeshAgent.speed = 10f; //유닛의 속도
        navMeshAgent.SetDestination(pos); //유닛의 목적지를 설정함
    }
}
