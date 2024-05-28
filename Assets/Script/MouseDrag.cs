using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    [SerializeField] private RectTransform dragRectangle = null;  

    private Rect dragRect = default;
    private Vector2 start = Vector2.zero; //�簢���� ���� ��ġ
    private Vector2 end = Vector2.zero; //�簢���� ������ ��ġ

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
            start  = Input.mousePosition; //ó�� Ŭ�������� ��ġ
            dragRect = new Rect();
        }

        if (Input.GetMouseButton(0))
        {
            end = Input.mousePosition; //�巡�� �� ��ġ

            DrawDragRectangle(); //�巡�� ���� �簢���� �׷���
        }

        if (Input.GetMouseButtonUp(0))
        {

            CalculateDragRect();
            SelectUnits();


            start = end = Vector2.zero; //�簢�� �����
            DrawDragRectangle();
        }
    }

    /// <summary>
    /// �巡���� ������ �׷��ִ� �Լ�
    /// </summary>
    private void DrawDragRectangle()
    {
        dragRectangle.position = (start + end) * 0.5f; //start�� end���� �߰����� ���� �巡���� ������ �߰����� ��Ʈ�� ��ġ�� �Ѵ�

        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y)); //start�� end�� ���� �巡���� ������ ���Ѵ�
    }

    /// <summary>
    /// �巡���� ������ ��Ʈ�� �̿��� ���ϴ� �Լ� 
    /// </summary>
    private void CalculateDragRect()
    {
        
        if (Input.mousePosition.x < start.x) //���콺�� �Ʒ��� �������� �巡�� ������
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else //���콺�� ������ �Ʒ��� �巡�� ������
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
    /// �巡���� �����ȿ� �ִ� ������ selectedUnitList�� �־��ִ� �Լ�
    /// </summary>
    private void SelectUnits()
    {
        foreach(UnitController unit in rtsUnitController.UnitList) //UnitList�� ��Ұ� �ִ� ����ŭ ����
        {
            if (dragRect.Contains(mainCamera.WorldToScreenPoint(unit.transform.position))) //��Ʈ ���� ���� ������ �ִٸ� ����
            {
                rtsUnitController.DragSelectUnit(unit); //unit�� ���� ���� ������Ʈ�� selectedUnitList�� �־���
            }
        }
    }
}
