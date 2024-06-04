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
    /// ������ �����Ҷ� ����Ǵ� �Լ�
    /// </summary>
    public override void SelectUnit()
    {
        isSelect = true;
        base.SelectUnit();
        UIPenal.SetActive(true);
    }

    /// <summary>
    /// ������ ���õ��� �ʾ����� ����Ǵ� �Լ�
    /// </summary>
    public override void DeselectUnit()
    {
        isSelect = false;
        base.DeselectUnit();
        UIPenal.SetActive(false);
    }

    /// <summary>
    /// ������ ������ spawnUnitList�� �־���
    /// </summary>
    /// <param name="spawnUnit">��ȯ�� ����</param>
    /// <param name="data">��ȯ�� ������ ������</param>
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
    /// ������ ������ �����ϴ� �ڷ�ƾ
    /// </summary>
    /// <param name="spawnUnit">��ȯ�� ����</param>
    /// <param name="data">��ȯ�� ������ ������</param>
    /// <returns></returns>
    private IEnumerator Co_UnitSpawnLogic(GameObject spawnUnit, UnitData data)
    {
        while (unitSpawnList.Contains(spawnUnit)) //spawnUnitList�� ���� �������� ��
        {
            if (isSpawn == false) //spawnUnitList�� ù �κ��� ������� �ʰ� ���� ���� �ƴҶ�
            {
                isSpawn = true; //���� ��
                unitSpawnTime = data.SpawnTime; //��ȯ�� ������ ���ѽð��� �Ҵ��Ŵ

                while (true) //���� �ݺ�
                {
                    time += Time.deltaTime; //�ð��� ����

                    timeSlider.value = time / unitSpawnTime; //�ð� �����̴��� ���� �ð��� �Ҵ���

                    if (time >= unitSpawnTime) //������ ��ȯ �ð� ���� ���� �ð��� �� Ŭ�� ����
                    {
                        time = 0; //�ð� �ʱ�ȭ
                        timeSlider.value = 0; //�ð� �����̴� �ʱ�ȭ

                        GameObject instantiatedUnit = Instantiate(unitSpawnList[0], unitSpawnPos.position, Quaternion.identity);

                        Unit unit = instantiatedUnit.GetComponent<Unit>(); //���� ��ü���� ���� ��ũ��Ʈ�� �Ҵ���

                        if (unit.navMeshAgent == null) //������ �׺�޽ð� ��� �ִٸ� 
                        {
                            unit.navMeshAgent = instantiatedUnit.GetComponent<NavMeshAgent>(); //�׺�޽ø� �߰���
                        }

                        unit.Move(unitSpawnMovePos.position); //��ȯ�� ������ ������ ��ġ�� �̵���Ŵ

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
                        isSpawn = false; //���� ���� �ƴ�

                        break; //���� ���� ����
                    }
                    yield return null; //�� ������ ��
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
