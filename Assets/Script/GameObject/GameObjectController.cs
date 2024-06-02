using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GameObjectController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker = null; //������ ���õ��� ���� ǥ���ϴ� ��Ŀ


    /// <summary>
    /// ������ ���õ��� �� ���� �Ǵ� �Լ�
    /// </summary>
    public virtual void SelectUnit()
    {
        unitMarker.SetActive(true); //��Ŀ�� ���ش�
    }
    /// <summary>
    /// ������ ���õ��� �ʾ��� �� ���� �Ǵ� �Լ�
    /// </summary>
    public virtual void DeselectUnit()
    {
        unitMarker.SetActive(false); //��Ŀ�� ���ش�
    }

}