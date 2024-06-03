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
    //[SerializeField] private Sprite OriginIcon = null;
    //[SerializeField] private float maxHp = default;

    [Header("BuildingUI")]
    [SerializeField] private Slider timeSlider = null;
    public GameObject[] unitSpawnIcon = null;
    //public Queue<GameObject> unitSpawnQueue = new Queue<GameObject>();
    public List<GameObject> unitSpawnList = new List<GameObject>();


    //private variable
    //private const int maxArraySize = 5;
    private float unitSpawnTime = default;
    private float time = 0;
    private bool isSpawn = false;

    //public int MaxArraySize { get { return maxArraySize; } }

    /// <summary>
    /// ������ �����Ҷ� ����Ǵ� �Լ�
    /// </summary>
    public override void SelectUnit()
    {
        base.SelectUnit();
        buildingUiPenal.SetActive(true);
    }

    /// <summary>
    /// ������ ���õ��� �ʾ����� ����Ǵ� �Լ�
    /// </summary>
    public override void DeselectUnit()
    {
        base.DeselectUnit();
        buildingUiPenal.SetActive(false);
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

                        GameObject instantiatedUnit = Instantiate(unitSpawnList[0], buildingSpawnPos.position, Quaternion.identity);

                        Unit unit = instantiatedUnit.GetComponent<Unit>(); //���� ��ü���� ���� ��ũ��Ʈ�� �Ҵ���

                        if (unit.navMeshAgent == null) //������ �׺�޽ð� ��� �ִٸ� 
                        {
                            unit.navMeshAgent = instantiatedUnit.GetComponent<NavMeshAgent>(); //�׺�޽ø� �߰���
                        }

                        unit.Move(unitPos.position); //��ȯ�� ������ ������ ��ġ�� �̵���Ŵ

                        // Change Default Image
                        //UnitsPanel.instance._data[0].image.sprite = UnitsPanel.instance.dafaultImage;



                        unitSpawnList.RemoveAt(0);

                        isSpawn = false; //���� ���� �ƴ�

                        break; //���� ���� ����
                    }
                    yield return null; //�� ������ ��
                }
            }
            yield return null;
        }
    }
}
