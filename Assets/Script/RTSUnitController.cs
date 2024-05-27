using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSUnitController : MonoBehaviour
{
    [SerializeField] private UnitSpawner unitSpawner = null; //UnitSpawner ��ũ��Ʈ
    private List<UnitController> selectedUnitList = null; //UnitController Ÿ���� ������ ������ �ִ� ����Ʈ
    public List<UnitController> UnitList { private set; get; } //��ũ��Ʈ ���ο��� ���� ��ȯ ��Ű�� �ܺο��� ���� ���� �� �� �ִ� ������Ƽ

    private void Awake()
    {
        selectedUnitList = new List<UnitController>(); //��ü ����Ʈ ����
        UnitList = unitSpawner.SpawnUnits(); //UnitList�� UnitSpawner���� ���� ����Ʈ�� �Ҵ�����
    }

    /// <summary>
    /// Ŭ������ ������ ���� ������ ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newUnit">UnitControllerŸ���� ��ü</param>
    public void ClickSelectUnit(UnitController newUnit)
    {
        DeselectAll(); //selectedUnitList�� ����ִ� ������ ���� ������

        SelectUnit(newUnit); //������ ������ selectedUnitList�� �־���
    } 
    /// <summary>
    /// ���� ����Ʈ�� ������ ������ �����Ҷ� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="newUnit">UnitControllerŸ���� ��ü</param>
    public void ShiftSelectUnit(UnitController newUnit)
    {
        if(selectedUnitList.Contains(newUnit)) //����Ʈ�� newUnit�ִٸ� ����
        {
            DeselectUnit(newUnit); //������ ������Ŵ
        }
        else
        {
            SelectUnit(newUnit); //����Ʈ�� newUnit�� ���ٸ� ������
        }
    } 
     /// <summary>
     /// �巹�׸� �ؼ� ������ �����Ҷ� ����Ǵ� �Լ�
     /// </summary>
     /// <param name="newUnit"></param>
    public void DragSelectUnit(UnitController newUnit)
    {
        if(!selectedUnitList.Contains(newUnit)) //����Ʈ�� newUnit�� ���ٸ� ����
        {
            SelectUnit(newUnit); //newUnit�� selectedUnitList�� �־���
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
    /// <param name="newUnit">UnitControllerŸ���� ��ü</param>
    private void SelectUnit(UnitController newUnit)
    {
        newUnit.SelectUnit(); //UnitController ���� �ִ� SelectUnit�Լ� ����

        selectedUnitList.Add(newUnit); //slectedUnitList����Ʈ�� ���õ� ������ �־���
    }
    /// <summary>
    /// ������ ���õ��� �ʾ����� ���� �Ǵ� �Լ�
    /// </summary>
    /// <param name="newUnit">UnitControllerŸ���� ��ü</param>
    private void DeselectUnit(UnitController newUnit)
    {
        newUnit.DeselectUnit(); //UnitController ���� �ִ� DeselectUnit�Լ� ����

        selectedUnitList.Remove(newUnit); //selectedUnitList����Ʈ���� ������ ��
    }
}
