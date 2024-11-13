using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuStoreV2 : MonoBehaviour
{
    [Header("Manager Coins")]
    public CoinManager coinManager;
    public int coins;
    [Header("Ui")]
    public Text coinsText;

    void Update()
    {
        UpdateCoinsText();
    }
    public void UpdateCoinsText()
    {
        coins = coinManager.GetCoins();
        //coinsText.text = "Moedas: " + coins.ToString();
        coinsText.text = coins.ToString();
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
    public void EnableGameObjects(GameObject[] gameObjects)
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