using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : GameObjectController
{
    [Header("BuildingInfo")]
    [SerializeField] private GameObject buildingUiPenal;
    public override void SelectUnit()
    {
        base.SelectUnit();
        buildingUiPenal.SetActive(true);
    }

    public override void DeselectUnit()
    {
        base.DeselectUnit();
        buildingUiPenal.SetActive(false);
    }
}
