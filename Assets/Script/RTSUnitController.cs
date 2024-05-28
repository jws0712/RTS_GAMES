using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    //[SerializeField] private UnitSpawner unitSpawner = null; //UnitSpawner ��ũ��Ʈ
    [SerializeField] private GameObjectFinder gameObjectFinder = null;
    private List<GameObjectController> selectedUnitList = null; //���õ� ������ ��� ����Ʈ
    public List<GameObjectController> UnitList { private set; get; } //������ �־��ִ� ����Ʈ �̰� ��ũ��Ʈ ���ο��� ���� ��ȯ ��Ű�� �ܺο��� ���� ���� �� �� �ִ� ������Ƽ �̴�
    public List<GameObjectController> objectList { private set; get; }

    private void Awake()
    {
        selectedUnitList = new List<GameObjectController>(); //��ü ����Ʈ ����
        //UnitList = unitSpawner.SpawnUnits(); //UnitList�� SpawnUnits���� ������� ������ �߰�����
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
        if(selectedUnitList.Contains(newObject)) //���õ� ������ �ٽ� �����ϸ� ����
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
        if(!selectedUnitList.Contains(newObject)) //����Ʈ�� newUnit�� ���ٸ� ����
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
        for(int i = 0; i < selectedUnitList.Count; i++) //����Ʈ�� ���� ��ŭ �ݺ���
        {
            selectedUnitList[i].MoveTo(end); //i��° ������ end�� ������
        }
    }
    /// <summary>
    /// ���õ� ���ֵ��� ��� ���� ���� ��Ŵ
    /// </summary>
    public void DeselectAll()
    {
        for(int i = 0; i < selectedUnitList.Count; i++) //selectedUnitList�� ���� ��ŭ �ݺ�
        {
            selectedUnitList[i].DeselectUnit(); //i��°�� ������ ���� ���� ��Ŵ
        }

        selectedUnitList.Clear(); //����Ʈ�� ��� ��Ҹ� ����
    }
    /// <summary>
    /// ������ ���������� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newObject">UnitControllerŸ���� ��ü</param>
    private void SelectUnit(GameObjectController newObject)
    {
        newObject.SelectUnit(); //UnitController ���� �ִ� SelectUnit�Լ� ����

        selectedUnitList.Add(newObject); //slectedUnitList����Ʈ�� ���õ� ������ �־���
    }
    /// <summary>
    /// ������ ���õ��� �ʾ����� ���� �Ǵ� �Լ�
    /// </summary>
    /// <param name="newObject">UnitControllerŸ���� ��ü</param>
    private void DeselectUnit(GameObjectController newObject)
    {
        newObject.DeselectUnit(); //UnitController ���� �ִ� DeselectUnit�Լ� ����

        selectedUnitList.Remove(newObject); //selectedUnitList����Ʈ���� ������ ��
    }
}
