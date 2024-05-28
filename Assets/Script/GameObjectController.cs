using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameObjectController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker = null; //유닛이 선택됐을 때를 표시하는 마커
    private NavMeshAgent navMeshAgent = null; //유닛 오브젝트내에 있는 에이전트

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //에이전트를 가져옴
    }
    /// <summary>
    /// 유닛이 선택됐을 때 실행 되는 함수
    /// </summary>
    public void SelectUnit()
    {
        unitMarker.SetActive(true); //마커를 켜준다
    }
    /// <summary>
    /// 유닛이 선택되지 않았을 때 실행 되는 함수
    /// </summary>
    public void DeselectUnit()
    {
        unitMarker.SetActive(false); //마커를 꺼준다
    }

    /// <summary>
    /// NavMesh를 사용해서 유닛 오브젝트를 pos로 이동시키는 함수
    /// </summary>
    /// <param name="pos">유닛의 목적지</param>
    public void MoveTo(Vector3 pos)
    {
        navMeshAgent.speed = 10f; //유닛의 속도
        navMeshAgent.SetDestination(pos); //유닛의 목적지를 설정함
    }
}
