using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private LayerMask layerUnit = default;
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
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerUnit)) 
            {
                if(hit.transform.GetComponent<UnitController>() == null) return;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.ShiftSelectUnit(hit.transform.GetComponent<UnitController>());
                }
                else
                {
                    rtsUnitController.ClickSelectUnit(hit.transform.GetComponent<UnitController>());
                }
            }

            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    rtsUnitController.DeselectAll();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
            {
                rtsUnitController.MoveSelectedUnits(hit.point);
            }
        }
    }
}
