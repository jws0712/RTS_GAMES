using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Building : GameObjectController
{
    [Header("BuildingInfo")]
    [SerializeField] private GameObject buildingUiPenal = null;
    [SerializeField] private Transform buildingSpawnPos = null;
    [SerializeField] private Transform unitPos = null;
    [SerializeField] private float maxHp = default;

    [Header("BuildingUI")]
    [SerializeField] private Slider timeSlider = null;

    //private variable
    private const int maxArraySize = 6;
    private float unitSpawnTime = default;
    private float time = 0;
    private List<GameObject> spawnUnitList = new List<GameObject>(maxArraySize);
    private bool isSpawn = false;
    
    /// <summary>
    /// 유닛을 선택할때 실행되는 함수
    /// </summary>
    public override void SelectUnit()
    {
        base.SelectUnit();
        buildingUiPenal.SetActive(true);
    }

    /// <summary>
    /// 유닛의 선택되지 않았을때 실행되는 함수
    /// </summary>
    public override void DeselectUnit()
    {
        base.DeselectUnit();
        buildingUiPenal.SetActive(false);
    }

    /// <summary>
    /// 스폰할 유닛을 spawnUnitList에 넣어줌
    /// </summary>
    /// <param name="spawnUnit">소환할 유닛</param>
    /// <param name="data">소환할 유닛을 데이터</param>
    public void AddSpawnUnit(GameObject spawnUnit, UnitData data)
    {
        if (spawnUnitList.Count < maxArraySize)
        {
            spawnUnitList.Add(spawnUnit);
        }

        StartCoroutine(Co_UnitSpawnLogic(spawnUnit, data));
    }

    /// <summary>
    /// 유닛의 스폰을 실행하는 코루틴
    /// </summary>
    /// <param name="spawnUnit">소환할 유닛</param>
    /// <param name="data">소환할 유닛의 데이터</param>
    /// <returns></returns>
    private IEnumerator Co_UnitSpawnLogic(GameObject spawnUnit, UnitData data)
    {
        while (spawnUnitList.Count != 0) //spawnUnitList가 전부 빌때까지 돔
        {
            if (spawnUnitList[0] != null && isSpawn == false) //spawnUnitList의 첫 부분이 비어있지 않고 스폰 중이 아닐때
            {
                isSpawn = true; //스폰 중
                unitSpawnTime = data.SpawnTime; //소환할 유닛의 소한시간을 할당시킴

                while (true) //무한 반복
                {
                    time += Time.deltaTime; //시간을 더함

                    timeSlider.value = time / unitSpawnTime; //시간 슬라이더에 현재 시간을 할당함

                    if (time >= unitSpawnTime) //유닛의 소환 시간 보다 현재 시간이 더 클때 실행
                    {
                        time = 0; //시간 초기화
                        timeSlider.value = 0; //시간 슬라이더 초기화

                        GameObject instantiatedUnit = Instantiate(spawnUnit, buildingSpawnPos.position, Quaternion.identity); //유닛 객체를 할당함
                        Unit unit = instantiatedUnit.GetComponent<Unit>(); //유닛 객체에서 유닛 스크립트를 할당함

                        if (unit.navMeshAgent == null) //유닛의 네브메시가 비어 있다면 
                        {
                            unit.navMeshAgent = instantiatedUnit.GetComponent<NavMeshAgent>(); //네브메시를 추가함
                        }

                        unit.Move(unitPos.position); //소환된 유닛을 설정한 위치로 이동시킴

                        spawnUnitList.RemoveAt(0); //리스트에서 유닛을 뺌

                        isSpawn = false; //스폰 중이 아님

                        break; //무한 루프 멈춤
                    }
                    yield return null; //한 프래임 쉼
                }
            }
            yield return null; //한 프래임 쉼
        }
    }
}
