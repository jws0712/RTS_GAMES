using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    //[SerializeField] private UnitSpawner unitSpawner = null; //UnitSpawner ��ũ��Ʈ
    [SerializeField] private GameObjectFinder gameObjectFinder = null;
    private List<GameObjectController> selectedObjectList = null; //���õ� ������ ��� ����Ʈ

    public List<GameObjectController> objectList { private set; get; }


    private void Awake()
    {
        selectedObjectList = new List<GameObjectController>(); //��ü ����Ʈ ����
        //UnitList = unitSpawner.SpawnUnits(); //UnitList�� SpawnUnits���� ������� ������ �߰�����
    }

    private void Update()
    {
        objectList = gameObjectFinder.FindObject(); //objectList�� FindObject���� ã�� ������ �־���
    }


    /// <summary>
    /// Ŭ������ ������ ���� ������ ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newOject">UnitControllerŸ���� ��ü</param>
    public void ClickSelectUnit(GameObjectController newOject)
    {
        DeselectAll(); //selectedUnitList�� ����ִ� ������ ���� ������

        SelectUnit(newOject); //������ ������ selectedUnitList�� �־���
    } 
    /// <summary>
    /// ���� ����Ʈ�� ������ ������ �����Ҷ� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newObject">UnitControllerŸ���� ��ü</param>
    public void ShiftSelectUnit(GameObjectController newObject)
    {
        if(selectedObjectList.Contains(newObject)) //���õ� ������ �ٽ� �����ϸ� ����
        {
            DeselectUnit(newObject); //������ ������Ŵ
        }
        else //���ο� ������ �����ϸ� ����
        {
            SelectUnit(newObject); //������ ������
        }
    } 
     /// <summary>
     /// �巹�׸� �ؼ� ������ �����Ҷ� ����Ǵ� �Լ�
     /// </summary>
     /// <param name="newObject"></param>
    public void DragSelectUnit(GameObjectController newObject)
    {
        if(!selectedObjectList.Contains(newObject)) //����Ʈ�� newUnit�� ���ٸ� ����
        {
            SelectUnit(newObject); //newUnit�� selectedUnitList�� �־���
        }
    }
    /// <summary>
    /// ���õ� ���ֵ��� ������ ��ġ�� �̵���Ŵ
    /// </summary>
    /// <param name="end">������ ������</param>
    public void MoveSelectedUnits(Vector3 end)
    {
        for(int i = 0; i < selectedObjectList.Count; i++) //����Ʈ�� ���� ��ŭ �ݺ���
        {
            if (selectedObjectList[i].GetComponent<Unit>() != null)
            {
                selectedObjectList[i].GetComponent<Unit>().Move(end); //i��° ������ end�� ������
            }
        }
    }
    /// <summary>
    /// ���õ� ���ֵ��� ��� ���� ���� ��Ŵ
    /// </summary>
    public void DeselectAll()
    {
        for(int i = 0; i < selectedObjectList.Count; i++) //selectedUnitList�� ���� ��ŭ �ݺ�
        {
            selectedObjectList[i].DeselectUnit(); //i��°�� ������ ���� ���� ��Ŵ
        }

        selectedObjectList.Clear(); //����Ʈ�� ��� ��Ҹ� ����
    }
    /// <summary>
    /// ������ ���������� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newObject">UnitControllerŸ���� ��ü</param>
    private void SelectUnit(GameObjectController newObject)
    {
        newObject.SelectUnit(); //UnitController ���� �ִ� SelectUnit�Լ� ����

        selectedObjectList.Add(newObject); //slectedUnitList����Ʈ�� ���õ� ������ �־���
    }
    /// <summary>
    /// ������ ���õ��� �ʾ����� ���� �Ǵ� �Լ�
    /// </summary>
    /// <param name="newObject">UnitControllerŸ���� ��ü</param>
    private void DeselectUnit(GameObjectController newObject)
    {
        newObject.DeselectUnit(); //UnitController ���� �ִ� DeselectUnit�Լ� ����

        selectedObjectList.Remove(newObject); //selectedUnitList����Ʈ���� ������ ��
    }
}
