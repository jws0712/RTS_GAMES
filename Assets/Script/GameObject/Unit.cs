using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Unit : GameObjectController
{

    [Header("UnitInfo")]
    [SerializeField] private GameObject unitUiPanel;

    [SerializeField] private UnitData unitData = null;

    

    //Components 
    public NavMeshAgent navMeshAgent = null; //유닛 오브젝트내에 있는 에이전트

    //private variable
    private float damage = default;
    private float speed = default;
    private float maxHP = default;
    private float attackDistance = default;
    private Sprite unitIcon = null;

    private void OnEnable()
    {
        if (navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>(); //에이전트를 가져옴            
        }

        SetObjectData();
    }

    /// <summary>
    /// UnitData에서 받아온 변수들을 초기화 하는 함수
    /// </summary>
    protected void SetObjectData()
    {
        damage = unitData.Damage;
        speed = unitData.Speed;
        maxHP = unitData.MaxHP;
        attackDistance = unitData.AttackDistance;
        unitIcon = unitData.UnitIcon;
    }


    /// <summary>
    /// NavMesh를 사용해서 유닛 오브젝트를 pos로 이동시키는 함수
    /// </summary>
    /// <param name="pos">유닛의 목적지</param>
    public void Move(Vector3 pos)
    {
        navMeshAgent.speed = speed; //유닛의 속도
        navMeshAgent.SetDestination(pos); //유닛의 목적지를 설정함
        Debug.Log("이동");
        Debug.Log(pos);
    }

    public override void SelectUnit()
    {
        base.SelectUnit();
        unitUiPanel.SetActive(true);
    }

    public override void DeselectUnit()
    {
        base.DeselectUnit();
        unitUiPanel.SetActive(false);
    }
}
