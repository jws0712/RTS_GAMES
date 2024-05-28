using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFinder : MonoBehaviour
{
    public List<GameObjectController> FindObject()
    {
        List<GameObjectController> gameObjectList = new List<GameObjectController>(FindObjectsOfType<GameObjectController>()); //씬에 있는 GameObjectController타입을 가진 모든 오브젝트를 찾아서 리스트에 넣음

        return gameObjectList;
    }
}
