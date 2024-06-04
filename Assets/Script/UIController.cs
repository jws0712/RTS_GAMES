using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{

    [Space(10f)]
    [SerializeField] private Button worker = null;
    [SerializeField] private GameObject workerGameObject = null;
    [SerializeField] private UnitData workerUnitData = null;
    [Space(10f)]
    [SerializeField] private Button magic = null;
    [SerializeField] private GameObject magicGameObject = null;
    [SerializeField] private UnitData magicUnitData = null;

    [Space(10f)]
    [SerializeField] private Button archer = null;
    [SerializeField] private GameObject archerGameObject = null;
    [SerializeField] private UnitData archerUnitData = null;

    [Space(10f)]
    [SerializeField] private Button spear = null;
    [SerializeField] private GameObject spearGameObject = null;
    [SerializeField] private UnitData spearUnitData = null;

    [Space(10f)]
    [SerializeField] private Button griffin = null;
    [SerializeField] private GameObject griffinGameObject = null;
    [SerializeField] private UnitData griffinUnitData = null;

    [Space(10f)]
    [SerializeField] private Button knight = null;
    [SerializeField] private GameObject knightGameObject = null;
    [SerializeField] private UnitData kngihtUnitData = null;

    [Space(10f)]
    [SerializeField] private Button horse = null;
    [SerializeField] private GameObject horseGameObject = null;
    [SerializeField] private UnitData horseUnitData = null;

    [Space(10f)]
    [SerializeField] private Button tank = null;
    [SerializeField] private GameObject tankGameObject = null;
    [SerializeField] private UnitData tankUnitData = null;

    private Building building = null;

    private void Awake()
    {
        building = GetComponent<Building>();
    }

    private void Start()
    {
        worker.onClick.AddListener(() => SpawnUnit(workerGameObject, workerUnitData));
        archer.onClick.AddListener(() => SpawnUnit(archerGameObject, archerUnitData));
        magic.onClick.AddListener(() => SpawnUnit(magicGameObject, magicUnitData));
        spear.onClick.AddListener(() => SpawnUnit(spearGameObject, spearUnitData));
        horse.onClick.AddListener(() => SpawnUnit(horseGameObject, horseUnitData));
        griffin.onClick.AddListener(() => SpawnUnit(griffinGameObject, griffinUnitData));
        tank.onClick.AddListener(() => SpawnUnit(tankGameObject, tankUnitData));
        knight.onClick.AddListener(() => SpawnUnit(knightGameObject, kngihtUnitData));
    }

    private void SpawnUnit(GameObject gameObject, UnitData data)
    {
        building.AddSpawnUnit(gameObject, data);
        //foreach(var panel in UnitsPanel.instance._data)
        //{
        //    if(!panel.isUsing)
        //    {
        //        panel.isUsing = true;
        //        panel.image.sprite = data.UnitIcon;
        //        break;
        //    }
        //}
    }
}
