using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : GameObjectController
{
    [Header("BuildingInfo")]
    [SerializeField] private GameObject buildingUiPenal = null;
    [SerializeField] private Transform buildingSpawnPos = null;

    [SerializeField] private float maxHp = default;

    //private variable
    private const int maxArraySize = 6;
    private float time = 0;

    public float currentTime { get { return  time; } }
    
    public override void SelectUnit()
    {
        base.SelectUnit();
        buildingUiPenal.SetActive(true);
    }

    public override void DeselectUnit()
    {
        base.DeselectUnit();
        buildingUiPenal.SetActive(false);
    }

    public virtual void UnitSpawnArray(GameObject spawnUnit)
    {
        List<GameObject> spawnUnitList = new List<GameObject>(maxArraySize);

        spawnUnitList.Add(spawnUnit);

        float spawnTime = spawnUnit.GetComponent<Unit>().SpawnTime;

        if (spawnUnitList[0] != null)
        {
            Instantiate(spawnUnitList[0], buildingSpawnPos.position, Quaternion.identity);
        }
    }
}
