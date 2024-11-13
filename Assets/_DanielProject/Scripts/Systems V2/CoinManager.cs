using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Referência estática para acesso global

    public int startingCoins = 0; // Quantidade inicial de moedas
    private int currentCoins; // Moedas atuais do jogador

    private const string PlayerPrefsKey = "PlayerCoins"; // Chave para acessar as moedas no PlayerPrefs

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        // Carrega as moedas salvas ou define a quantidade inicial
        currentCoins = PlayerPrefs.GetInt(PlayerPrefsKey, startingCoins);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        SaveCoins();
        Debug.Log("Add");
    }

    public void RemoveCoins(int amount)
    {
        currentCoins -= amount;
        SaveCoins();
    }

    public int GetCoins()
    {
        return currentCoins;
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(PlayerPrefsKey, currentCoins);
        PlayerPrefs.Save();
    }
}

