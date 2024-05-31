using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : GameObjectController
{

    [Header("UnitInfo")]
    [SerializeField] private GameObject unitUiPanel;

    [SerializeField] private UnitData unitData = null;



    //Components 
    private NavMeshAgent navMeshAgent = null; //���� ������Ʈ���� �ִ� ������Ʈ

    //private variable
    private float damage = default;
    private float speed = default;
    private float maxHP = default;
    private float spawnTime = default;
    private float attackDistance = default;

    //public variable
    public UnitData UnitData { get { return unitData; } }

    public float SpawnTime { get { return spawnTime; } }


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //������Ʈ�� ������
    }

    private void Start()
    {
        SetObjectData();
    }

    /// <summary>
    /// UnitData���� �޾ƿ� �������� �ʱ�ȭ �ϴ� �Լ�
    /// </summary>
    protected void SetObjectData()
    {
        damage = unitData.Damage;
        speed = unitData.Speed;
        maxHP = unitData.MaxHP;
        spawnTime = unitData.SpawnTime;
        attackDistance = unitData.AttackDistance;
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
