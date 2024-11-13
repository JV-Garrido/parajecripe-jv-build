using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainItem : MonoBehaviour
{
    private static MainItem instance;

    private bool canActivate;
    [Header("Name item ID")]
    public string idItem;
    [Header("Item")]
    public GameObject item;
    //public GameObject itemPadrao;
    public GameObject[] otherGameObjects;

    private void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey(idItem))
        {
            // Obtém o valor armazenado na chave "canActivate"
            canActivate = PlayerPrefs.GetInt(idItem) == 1;
        }
        // Ativa ou desativa o GameObject com base no valor de canActivate
        item.SetActive(canActivate);
        if (canActivate == true)
        {
            DisableGameObjects(otherGameObjects);
        }
    }
    private void Start()
    {
        // Verifica se o PlayerPrefs contém a chave "canActivate"
        if (PlayerPrefs.HasKey(idItem))
        {
            // Obtém o valor armazenado na chave "canActivate"
            canActivate = PlayerPrefs.GetInt(idItem) == 1;
        }
        else
        {
            // Define o valor padrão para canActivate
            canActivate = false;
        }

        // Ativa ou desativa o GameObject com base no valor de canActivate
        item.SetActive(canActivate);
        if (canActivate == true)
        {
            DisableGameObjects(otherGameObjects);
        }

    }

    public void SetCanActivate(bool value)
    {
        // Define o valor de canActivate
        canActivate = value;

        // Armazena o valor de canActivate no PlayerPrefs
        PlayerPrefs.SetInt(idItem, canActivate ? 1 : 0);

        // Ativa ou desativa o GameObject com base no valor de canActivate
        gameObject.SetActive(canActivate);
    }

    public void CreateHasKey()
    {
        PlayerPrefs.SetInt(idItem, 0);
    }


    public void DisableGameObjects(GameObject[] gameObjects)
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
