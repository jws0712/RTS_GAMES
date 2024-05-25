using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField] private GameObject unitMarker = null;
    private NavMeshAgent navMeshAgent = null;

    private void Awake()
    {
        
    }

    public void SelectUnit()
    {
        unitMarker.SetActive(true);
    }

    public void DeselectUnit()
    {
        unitMarker.SetActive(false);
    }

    public void MoveTo(Vector3 pos)
    {
        navMeshAgent.SetDestination(pos);
    }
}
