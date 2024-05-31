using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("ButtonInfo")]
    [Space(10f)]
    [SerializeField] private Button worker = null;
    [SerializeField] private GameObject workerGameObject = null;
    [Space(10f)]
    [SerializeField] private Button magic = null;
    [SerializeField] private GameObject magicGameObject = null;
    [Space(10f)]
    [SerializeField] private Button archer = null;
    [SerializeField] private GameObject archerGameObject = null;
    [Space(10f)]
    [SerializeField] private Button spear = null;
    [SerializeField] private GameObject spearGameObject = null;
    [Space(10f)]
    [SerializeField] private Button griffin = null;
    [SerializeField] private GameObject griffinGameObject = null;
    [Space(10f)]
    [SerializeField] private Button knight = null;
    [SerializeField] private GameObject knightGameObject = null;
    [Space(10f)]
    [SerializeField] private Button horse = null;
    [SerializeField] private GameObject horseGameObject = null;
    [Space(10f)]
    [SerializeField] private Button tank = null;
    [SerializeField] private GameObject tankGameObject = null;

    private void Start()
    {
        worker.onClick.AddListener(() => SpawnWorker(workerGameObject));
        archer.onClick.AddListener(() => SpawnArcher(archerGameObject));
        magic.onClick.AddListener(() => SpawnMagic(magicGameObject));
        spear.onClick.AddListener(() => SpawnSpear(spearGameObject));
        horse.onClick.AddListener(() => SpawnHorse(horseGameObject));
        griffin.onClick.AddListener(() => SpawnGriffin(griffinGameObject));
        tank.onClick.AddListener(() => SpawnTank(tankGameObject));
        knight.onClick.AddListener(() => SpawnKnight(knightGameObject));
    }

    private void SpawnWorker(GameObject gameObject)
    {
        
    }

    private void SpawnArcher(GameObject gameObject)
    {

    }

    private void SpawnMagic(GameObject gameObject)
    {

    }

    private void SpawnSpear(GameObject gameObject)
    {

    }

    private void SpawnHorse(GameObject gameObject)
    {

    }

    private void SpawnGriffin(GameObject gameObject)
    {

    }

    private void SpawnTank(GameObject gameObject)
    {

    }

    private void SpawnKnight(GameObject gameObject)
    {

    }




}
