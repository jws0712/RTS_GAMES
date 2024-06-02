using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameObjectController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker = null; //유닛이 선택됐을 때를 표시하는 마커


    /// <summary>
    /// 유닛이 선택됐을 때 실행 되는 함수
    /// </summary>
    public virtual void SelectUnit()
    {
        unitMarker.SetActive(true); //마커를 켜준다
    }
    /// <summary>
    /// 유닛이 선택되지 않았을 때 실행 되는 함수
    /// </summary>
    public virtual void DeselectUnit()
    {
        unitMarker.SetActive(false); //마커를 꺼준다
    }

}