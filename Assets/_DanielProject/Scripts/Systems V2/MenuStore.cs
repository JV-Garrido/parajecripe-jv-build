using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStore : MonoBehaviour
{
    [Header("OnItem")]
    public GameObject[] onPlayersDisabled;
    public GameObject[] onPlayersEnable;
    [Header("OffItem")]
    public GameObject[] offPlayersDisabled;
    public GameObject[] offPlayersEnable;
    [Header("Scripts")]
    public MainItem mainItem;
    public ShopManagerV2 shopManager;
    string nameId;
    private void Start()
    {
        nameId = mainItem.idItem;
    }
    public void PanelActive()
    {
        if (PlayerPrefs.HasKey(nameId))
        {
            OnItem();
            Debug.Log("OnItem");
        }
        else
        {
            OffItem();
            Debug.Log("OffItem");
        }
    }

    void OffItem()
    {
        DisableGameObjects(offPlayersDisabled);
        EnableGameObjects(offPlayersEnable);
    }
    void OnItem()
    {
        DisableGameObjects(onPlayersDisabled);
        EnableGameObjects(onPlayersEnable);
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
    void EnableGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
}
