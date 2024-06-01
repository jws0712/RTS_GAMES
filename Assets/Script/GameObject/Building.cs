using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : GameObjectController
{
    [Header("BuildingInfo")]
    [SerializeField] private GameObject buildingUiPenal = null;
    [SerializeField] private Transform buildingSpawnPos = null;

    [SerializeField] private float maxHp = default;

    [Header("BuildingUI")]
    [SerializeField] private Slider timeSlider = null;

    //private variable
    private const int maxArraySize = 6;
    private float unitSpawnTime = default;
    private float time = 0;
    private List<GameObject> spawnUnitList = new List<GameObject>(maxArraySize);
    private bool isSpawn = false;

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

    public void AddSpawnUnit(GameObject spawnUnit, UnitData data)
    {
        if (spawnUnitList.Count < maxArraySize)
        {
            spawnUnitList.Add(spawnUnit);
            Debug.Log("�����߰�!");
        }

        StartCoroutine(Co_UnitSpawnLogic(spawnUnit, data));
    }

    private IEnumerator Co_UnitSpawnLogic(GameObject spawnUnit, UnitData data)
    {


        while (spawnUnitList.Count != 0) //����Ʈ�� 0�� �ɋ����� ��� ���ư�
        {
            if (spawnUnitList[0] != null && isSpawn == false) //����Ʈ�� ó�� �κп� ������Ʈ�� �ְ� ������ �� ��������
            {
                isSpawn = true;
                Debug.Log("���ּ�ȯ����!");
                unitSpawnTime = data.SpawnTime;

                while (true)
                {
                    time += Time.deltaTime;

                    timeSlider.value = time / unitSpawnTime;

                    if (time >= unitSpawnTime)
                    {
                        time = 0;
                        timeSlider.value = 0;
                        Instantiate(spawnUnit, buildingSpawnPos.position, Quaternion.identity);
                        spawnUnitList.Remove(spawnUnit);
                        Debug.Log("��ȯ�Ϸ�");

                        isSpawn = false;
                        break;
                    }
                    yield return null;
                }
            }
            yield return null;
        }

    }
}
