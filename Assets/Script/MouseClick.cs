using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer = default;
    [SerializeField] private LayerMask layerGround = default;
    private Camera mainCamera = null;
    private RTSUnitController rtsUnitController = null;

    private void Awake()
    {
        mainCamera = Camera.main;
        
        rtsUnitController = GetComponent< RTSUnitController>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) //���� Ŭ���� ������
        {
            RaycastHit hit;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //3���� ������ ���콺 Ŭ���� ��ġ�� ���̸� ��

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer)) //���̰� ���ֿ� �¾����� ����
            {
                if (hit.transform.GetComponent<GameObjectController>() == null) return; //���̸� ���� ������Ʈ�� UnitController�� ������ ���� ������ ������

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.ShiftSelectUnit(hit.transform.GetComponent<GameObjectController>()); //����Ʈ�� ����ä�� Ŭ�������� ShiftSelectUnit�� ���� newUnit�� ���̿� ���� ������Ʈ�� UnitController�� ������
                }
                else
                {
                    rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<GameObjectController>());  //Ŭ�������� ShiftSelectUnit�� ���� newUnit�� ���̿� ���� ������Ʈ�� UnitController�� ������
                }
            }

            else //���̰� ���ֿ� ���� �ʾҴٸ� ����
            {
                if (!Input.GetKey(KeyCode.LeftShift)) //����Ʈ �� ���������� ������
                {
                    rtsUnitController.DeselectAll(); //���õ� ������ ��� ����Ʈ���� ������
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) //������ Ŭ���� ������
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //3���� ������ ���콺 Ŭ���� ��ġ�� ���̸� ��

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround)) //���̰� ���� �¾����� ����
            {
                rtsUnitController.MoveSelectedUnits(hit.point); //������ ���̰� ���� ��ġ�� �̵���Ŵ
            }
        }
    }
}
