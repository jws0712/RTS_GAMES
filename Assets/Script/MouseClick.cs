using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask = default;
    private Camera mainCamera = null;
    private RTSUnitController rtsUnitController = null;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        rtsUnitController = GetComponent< RTSUnitController>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        }
    }
}
