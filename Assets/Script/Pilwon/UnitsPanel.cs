using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UnitsPanelData
{
    public Image image;
    public bool isUsing;
}

public class UnitsPanel : MonoBehaviour
{
    public static UnitsPanel instance;

    public Sprite dafaultImage;
    public  UnitsPanelData[] _data = new UnitsPanelData[5];

    private void Awake()
    {
        instance = this;

        Image[] tempUnitPanelImages = GetComponentsInChildren<Image>(); 

        for(int i = 0; i < _data.Length; i++)
            _data[i].image = tempUnitPanelImages[i];
    }
}
