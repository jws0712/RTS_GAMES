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
        if(Input.GetMouseButtonDown(0)) //왼쪽 클릭을 했을때
        {
            RaycastHit hit;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //3차원 공간에 마우스 클릭한 위치에 레이를 쏨

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, objectLayer)) //레이가 유닛에 맞았을때 실행
            {
                if (hit.transform.GetComponent<GameObjectController>() == null) return; //레이를 맞은 오브젝트가 UnitController를 가지고 있지 않으면 리턴함

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.ShiftSelectUnit(hit.transform.GetComponent<GameObjectController>()); //쉬프트를 누른채로 클릭했을때 ShiftSelectUnit을 실행 newUnit에 레이에 맞은 오브젝트의 UnitController를 가져옴
                }
                else
                {
                    rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<GameObjectController>());  //클릭했을때 ShiftSelectUnit을 실행 newUnit에 레이에 맞은 오브젝트의 UnitController를 가져옴
                }
            }

            else //레이가 유닛에 맞지 않았다면 실행
            {
                if (!Input.GetKey(KeyCode.LeftShift)) //쉬프트 가 눌러져있지 않을때
                {
                    rtsUnitController.DeselectAll(); //선택된 유닛을 모두 리스트에서 제거함
                }
            }
        }

        if (Input.GetMouseButtonDown(1)) //오른쪽 클릭을 했을때
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //3차원 공간에 마우스 클릭한 위치에 레이를 쏨

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround)) //레이가 땅에 맞았을때 실행
            {
                rtsUnitController.MoveSelectedUnits(hit.point); //유닛을 레이가 닿은 위치로 이동시킴
            }
        }
    }
}
