using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFinder : MonoBehaviour
{
    public List<GameObjectController> FindObject()
    {
        List<GameObjectController> gameObjectList = new List<GameObjectController>(FindObjectsOfType<GameObjectController>()); //���� �ִ� GameObjectControllerŸ���� ���� ��� ������Ʈ�� ã�Ƽ� ����Ʈ�� ����

        return gameObjectList;
    }
}
