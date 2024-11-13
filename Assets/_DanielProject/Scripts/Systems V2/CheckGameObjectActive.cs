using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameObjectActive : MonoBehaviour
{
    public GameObject[] desativarGameObjects;
    public GameObject gameObjectActive;

    private void Awake()
    {
        CheckActiveStatus();
    }
    private void Update()
    {
        CheckActiveStatus();
    }

    void CheckActiveStatus()
    {
        if (gameObjectActive.activeSelf)
        {
            //Debug.Log("O GameObject está ativo.");
        }
        else
        {
            DisableGameObjects(desativarGameObjects);
            //Debug.Log("O GameObject não está ativo.");
        }
    }
    void DisableGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}

