using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "ScriptableObject/UnitData", order = int.MaxValue)]
public class UnitData : ScriptableObject
{
    [SerializeField] private float damage = default;
    public float Damage {  get { return damage; } }

    [SerializeField] private float speed = default;
    public float Speed { get { return speed; } }

    [SerializeField] private float maxHP = default;
    public float MaxHP { get { return maxHP; } }

    [SerializeField] private float spawnTime = default;
    public float SpawnTime { get { return spawnTime; } }

    [SerializeField] private float attackDistance = default;
    public float AttackDistance { get { return attackDistance; } }

}
