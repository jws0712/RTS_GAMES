using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    //[SerializeField] private UnitSpawner unitSpawner = null; //UnitSpawner 스크립트
    [SerializeField] private GameObjectFinder gameObjectFinder = null;
    private List<GameObjectController> selectedObjectList = null; //선택된 유닛을 담는 리스트

    public List<GameObjectController> objectList { private set; get; }


    private void Awake()
    {
        selectedObjectList = new List<GameObjectController>(); //객체 리스트 생성
        //UnitList = unitSpawner.SpawnUnits(); //UnitList에 SpawnUnits에서 만들어진 유닛을 추가해줌
    }

    private void Update()
    {
        objectList = gameObjectFinder.FindObject(); //objectList에 FindObject에서 찾은 유닛을 넣어줌
    }


    /// <summary>
    /// 클릭으로 유닛을 선택 했을때 실행되는 함수
    /// </summary>
    /// <param name="newOject">UnitController타입의 객체</param>
    public void ClickSelectUnit(GameObjectController newOject)
    {
        DeselectAll(); //selectedUnitList에 들어있던 유닛을 전부 제거함

        SelectUnit(newOject); //선택한 유닛을 selectedUnitList에 넣어줌
    } 
    /// <summary>
    /// 왼쪽 쉬프트를 눌러서 유닛을 선택할때 실행되는 함수
    /// </summary>
    /// <param name="newObject">UnitController타입의 객체</param>
    public void ShiftSelectUnit(GameObjectController newObject)
    {
        if(selectedObjectList.Contains(newObject)) //선택된 유닛을 다시 선택하면 실행
        {
            DeselectUnit(newObject); //선택을 해제시킴
        }
        else //새로운 유닛을 선택하면 실행
        {
            SelectUnit(newObject); //유닛을 선택함
        }
    } 
     /// <summary>
     /// 드레그를 해서 유닛을 선택할때 실행되는 함수
     /// </summary>
     /// <param name="newObject"></param>
    public void DragSelectUnit(GameObjectController newObject)
    {
        if(!selectedObjectList.Contains(newObject)) //리스트에 newUnit이 없다면 실행
        {
            SelectUnit(newObject); //newUnit을 selectedUnitList에 넣어줌
        }
    }
    /// <summary>
    /// 선택된 유닛들을 지정한 위치로 이동시킴
    /// </summary>
    /// <param name="end">움직일 목적지</param>
    public void MoveSelectedUnits(Vector3 end)
    {
        for(int i = 0; i < selectedObjectList.Count; i++) //리스트의 길이 만큼 반복함
        {
            if (selectedObjectList[i].GetComponent<Unit>() != null)
            {
                selectedObjectList[i].GetComponent<Unit>().Move(end); //i번째 유닛을 end로 움직임
            }
        }
    }
    /// <summary>
    /// 선택된 유닛들을 모두 선택 해제 시킴
    /// </summary>
    public void DeselectAll()
    {
        for(int i = 0; i < selectedObjectList.Count; i++) //selectedUnitList의 길이 만큼 반복
        {
            selectedObjectList[i].DeselectUnit(); //i번째의 유닛을 선택 해제 시킴
        }

        selectedObjectList.Clear(); //리스트의 모든 요소를 제거
    }
    /// <summary>
    /// 유닛을 선택했을때 실행되는 함수
    /// </summary>
    /// <param name="newObject">UnitController타입의 객체</param>
    private void SelectUnit(GameObjectController newObject)
    {
        newObject.SelectUnit(); //UnitController 내에 있는 SelectUnit함수 실행

        selectedObjectList.Add(newObject); //slectedUnitList리스트에 선택된 유닛을 넣어줌
    }
    /// <summary>
    /// 유닛이 선택되지 않았을때 실행 되는 함수
    /// </summary>
    /// <param name="newObject">UnitController타입의 객체</param>
    private void DeselectUnit(GameObjectController newObject)
    {
        newObject.DeselectUnit(); //UnitController 내에 있는 DeselectUnit함수 실행

        selectedObjectList.Remove(newObject); //selectedUnitList리스트에서 유닛을 뺌
    }
}
