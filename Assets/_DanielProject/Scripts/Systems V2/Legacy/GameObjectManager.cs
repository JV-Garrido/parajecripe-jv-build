using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectManager : MonoBehaviour
{
    public bool IsGameObjectActive(GameObject gameObject)
    {
        if (gameObject != null)
        {
            return gameObject.activeSelf;
        }
        else
        {
            Debug.LogWarning("GameObject is null.");
            return false;
        }
    }
}

