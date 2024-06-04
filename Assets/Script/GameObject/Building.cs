using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Building : GameObjectController
{
    [Header("BuildingInfo")]
    [SerializeField] private GameObject UIPenal = null;
    [SerializeField] private Transform unitSpawnPos = null;
    [SerializeField] private Transform unitSpawnMovePos = null;
    [SerializeField] private Sprite defaultUnitIcon = null;
    [SerializeField] private LayerMask groundLayer = default;

    [Header("Camera")]
    [SerializeField] private Camera mainCamera = null;

    [Header("BuildingUI")]
    [SerializeField] private Slider timeSlider = null;
    [SerializeField] private Image[] unitSpawnIcon = null;

    //private variable
    private float unitSpawnTime = default;
    private float time = 0;
    private bool isSpawn = false;
    private bool isSelect = false;
    
    private List<GameObject> unitSpawnList = new List<GameObject>();
    private List<Sprite> unitIconList = new List<Sprite>();

    private void Update()
    {
        if(isSelect == true)
        {
            SetUnitSpawnMovePos();

        }
    }

    /// <summary>
    /// 유닛을 선택할때 실행되는 함수
    /// </summary>
    public override void SelectUnit()
    {
        isSelect = true;
        base.SelectUnit();
        UIPenal.SetActive(true);
    }

    /// <summary>
    /// 유닛의 선택되지 않았을때 실행되는 함수
    /// </summary>
    public override void DeselectUnit()
    {
        isSelect = false;
        base.DeselectUnit();
        UIPenal.SetActive(false);
    }

    /// <summary>
    /// 스폰할 유닛을 spawnUnitList에 넣어줌
    /// </summary>
    /// <param name="spawnUnit">소환할 유닛</param>
    /// <param name="data">소환할 유닛을 데이터</param>
    public void AddSpawnUnit(GameObject spawnUnit, UnitData data)
    {
        if (unitSpawnList.Count < 5)
        {
            unitSpawnList.Add(spawnUnit);
            unitIconList.Add(data.UnitIcon);

            for(int i = 0; i < unitSpawnList.Count; i++)
            {
                unitSpawnIcon[i].sprite = unitIconList[i];
            }

            StartCoroutine(Co_UnitSpawnLogic(spawnUnit, data));
        }
    }

    /// <summary>
    /// 유닛의 스폰을 실행하는 코루틴
    /// </summary>
    /// <param name="spawnUnit">소환할 유닛</param>
    /// <param name="data">소환할 유닛의 데이터</param>
    /// <returns></returns>
    private IEnumerator Co_UnitSpawnLogic(GameObject spawnUnit, UnitData data)
    {
        while (unitSpawnList.Contains(spawnUnit)) //spawnUnitList가 전부 빌때까지 돔
        {
            if (isSpawn == false) //spawnUnitList의 첫 부분이 비어있지 않고 스폰 중이 아닐때
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

                        GameObject instantiatedUnit = Instantiate(unitSpawnList[0], unitSpawnPos.position, Quaternion.identity);

                        Unit unit = instantiatedUnit.GetComponent<Unit>(); //유닛 객체에서 유닛 스크립트를 할당함

                        if (unit.navMeshAgent == null) //유닛의 네브메시가 비어 있다면 
                        {
                            unit.navMeshAgent = instantiatedUnit.GetComponent<NavMeshAgent>(); //네브메시를 추가함
                        }

                        unit.Move(unitSpawnMovePos.position); //소환된 유닛을 설정한 위치로 이동시킴

                        unitSpawnList.RemoveAt(0);
                        unitIconList.RemoveAt(0);

                        for (int i = 0; i < unitIconList.Count; i++)
                        {
                            unitSpawnIcon[i].sprite = unitIconList[i];
                        }

                        for(int i = unitIconList.Count; i < unitSpawnIcon.Length; i++)
                        {
                            if (unitSpawnIcon[i].sprite != defaultUnitIcon)
                            {
                                unitSpawnIcon[i].sprite = defaultUnitIcon;
                            }
                        }
                        isSpawn = false; //스폰 중이 아님

                        break; //무한 루프 멈춤
                    }
                    yield return null; //한 프래임 쉼
                }
            }
            yield return null;
        }
    }
    private void SetUnitSpawnMovePos()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                unitSpawnMovePos.position = hit.point;
            }
        }
    }
}
