using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab = null; //��ȯ�� ���� ������Ʈ
    [SerializeField] private int maxUnitCount = default; //��ȯ�� ������ ����

    private Vector2 minSize = new Vector2(-22, 22); //��ȯ�� ���� ������ ���� ���� ��ġ
    private Vector2 maxSize = new Vector2(22, -22); //��ȯ�� ���� ������ ���� ū ��ġ

    public List<UnitController> SpawnUnits() 
    {
        List<UnitController> unitList = new List<UnitController>(maxUnitCount); //maxUnitCount��ŭ�� UnitController��ü�� ����Ʈ�� ������

        for(int i = 0; i < maxUnitCount; i++) //��ȯ�� ������ ���� ��ŭ �ݺ�
        {
            Vector3 pos = new Vector3(Random.Range(minSize.x, maxSize.x), 0, Random.Range(minSize.y, maxSize.y)); //������ ���������� ������ ��ġ ����

            GameObject clone = Instantiate(unitPrefab, pos, Quaternion.identity); //������ Ŭ���� ������ ������ ������ ��ġ�� ����
            UnitController unit = clone.GetComponent<UnitController>(); //���ֿ��� UnitController�� ������ ���� unit�� �Ҵ���

            unitList.Add(unit); //������ ������ ���ָ���Ʈ�� �־���
        }

        return unitList; //������ ������ ���ָ���Ʈ�� ��ȯ��
    }
}
