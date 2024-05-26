using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab = null; //소환할 유닛 오브젝트
    [SerializeField] private int maxUnitCount = default; //소환할 유닛의 개수

    private Vector2 minSize = new Vector2(-22, 22); //소환할 유닛 범위의 가장 작은 위치
    private Vector2 maxSize = new Vector2(22, -22); //소환할 유닛 범위의 가장 큰 위치

    public List<UnitController> SpawnUnits() 
    {
        List<UnitController> unitList = new List<UnitController>(maxUnitCount); //maxUnitCount만큼의 UnitController객체의 리스트를 생성함

        for(int i = 0; i < maxUnitCount; i++) //소환한 유닛의 개수 만큼 반복
        {
            Vector3 pos = new Vector3(Random.Range(minSize.x, maxSize.x), 0, Random.Range(minSize.y, maxSize.y)); //지정한 범위내에서 랜덤한 위치 생성

            GameObject clone = Instantiate(unitPrefab, pos, Quaternion.identity); //유닛의 클론을 위에서 생성한 랜덤한 위치에 생성
            UnitController unit = clone.GetComponent<UnitController>(); //유닛에서 UnitController를 가지고 오고 unit에 할당함

            unitList.Add(unit); //위에서 생성한 유닛리스트에 넣어줌
        }

        return unitList; //유닛이 가득찬 유닛리스트를 반환함
    }
}
