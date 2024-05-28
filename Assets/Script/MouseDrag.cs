using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private RectTransform dragRectangle = null;  

    private Rect dragRect = default;
    private Vector2 start = Vector2.zero; //사각형의 시작 위치
    private Vector2 end = Vector2.zero; //사각형의 끝나는 위치

    private Camera mainCamera = null;
    private RTSUnitController rtsUnitController = null;

    private void Awake()
    {
        mainCamera = Camera.main;
        rtsUnitController = GetComponent< RTSUnitController>();

        DrawDragRectangle();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            start  = Input.mousePosition; //처음 클릭했을때 위치
            dragRect = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition; //드래그 중 위치

            DrawDragRectangle(); //드래그 범위 사각형을 그려줌
        }

        if (Input.GetMouseButtonUp(0))
        {

            CalculateDragRect();
            SelectUnits();


            start = end = Vector2.zero; //사각형 사라짐
            DrawDragRectangle();
        }
    }

    /// <summary>
    /// 드래그한 구역을 그려주는 함수
    /// </summary>
    private void DrawDragRectangle()
    {
        dragRectangle.position = (start + end) * 0.5f; //start와 end점의 중간점을 구해 드래그한 영역의 중간값을 랙트의 위치로 한다

        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y)); //start와 end를 빼서 드래그한 범위를 구한다
    }

    /// <summary>
    /// 드래그의 범위를 랙트를 이용해 구하는 함수 
    /// </summary>
    private void CalculateDragRect()
    {
        
        if (Input.mousePosition.x < start.x) //마우스를 아래서 위쪽으로 드래그 했을때
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else //마우스를 위에서 아래로 드래그 했을떄
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }
        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }


    }
    /// <summary>
    /// 드래그한 영역안에 있는 유닛을 selectedUnitList에 넣어주는 함수
    /// </summary>
    private void SelectUnits()
    {
        foreach(UnitController unit in rtsUnitController.UnitList) //UnitList에 요소가 있는 수만큼 만복
        {
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position))) //랙트 범위 내에 유닛이 있다면 실행
            {
                rtsUnitController.DragSelectUnit(unit); //unit에 들어온 유닛 오브젝트를 selectedUnitList에 넣어줌
            }
        }
    }
}
