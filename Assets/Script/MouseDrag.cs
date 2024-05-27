using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private RectTransform dragRectangle = null;  

    private Rect dragRect = default;
    private Vector2 start = Vector2.zero;
    private Vector2 end = Vector2.zero;

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
            start  = Input.mousePosition;
            dragRect = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition;

            DrawDragRectangle();
        }

        if (Input.GetMouseButtonUp(0))
        {

            CalculateDragRect();
            SelectUnits();


            start = end = Vector2.zero;
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

    private void CalculateDragRect()
    {
        if(Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
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

    private void SelectUnits()
    {
        foreach(UnitController unit in rtsUnitController.UnitList)
        {
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position)))
            {
                rtsUnitController.DragSelectUnit(unit);
            }
        }
    }
}
