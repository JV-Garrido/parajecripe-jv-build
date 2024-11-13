using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManagerV2 : MonoBehaviour
{
    [Header("Scripts")]
    public CoinManager coinManager;
    public MainItem mainItem;
   
    [Header("Valor do item")]
    public int itemPrice;
    [Header("UI")]
    public GameObject panelEquip;
    public GameObject panelBuy;
    public GameObject panelBoasVindas;
    public Text nameItemText;
    public Text nameEquipItemText;
    public Text princeItemText;
    //public string nameItem;
    [Header("Item")]
    public GameObject item;
    public GameObject[] otherGameObjects;
    int coins;
    bool trueBuy;
    string nameId;
    [Header("Anti-fail")]
    public bool antiFail;
    public GameObject padrao;

    private void Awake()
    {
     
        trueBuy = false;   
    }
    private void Start()
    {
        UpdateInfo();
    }
    public void BuyItem()
    {
        if (PlayerPrefs.HasKey(nameId))
        {
            panelEquip.SetActive(true);
            panelBoasVindas.SetActive(false);
            panelBuy.SetActive(false);
            Debug.Log("ja tem");
        }
        else
        {
           if(coins >= itemPrice) 
           {
                mainItem.CreateHasKey();
                coinManager.RemoveCoins(itemPrice);
                trueBuy = true;
                panelEquip.SetActive(true);
                panelBoasVindas.SetActive(false);
                panelBuy.SetActive(false);
                Debug.Log("buyItem");
            }
            
        }

        
    }
    public void EquipItem()
    {
       
        mainItem.SetCanActivate(true);
        item.SetActive(true);
        DisableGameObjects(otherGameObjects);
        Debug.Log("Equip");
    }
    public void DeseEquipItem()
    {
        
        mainItem.SetCanActivate(false);
        item.SetActive(false);
        if (antiFail == true)
        {
            padrao.SetActive(true);
        }
    }
    public void Experimentar()
    {
        item.SetActive(true);
        DisableGameObjects(otherGameObjects);
    }
    public void RetirarItem()
    {
        item.SetActive(false);
        if (antiFail == true)
        {
            padrao.SetActive(true);
        }
    }
    private void Update()
    {
        if(trueBuy == true)
        {
            mainItem.CreateHasKey();
        }
        if (PlayerPrefs.HasKey(nameId))
        {
            trueBuy = false;
        }

        UpdateInfo();

    }

    void UpdateInfo()
    {
        coins = coinManager.GetCoins();
        nameId = mainItem.idItem;
        nameEquipItemText.text = nameId;
        //nameItemText.text = nameItem;
        nameItemText.text = nameId;
        princeItemText.text = itemPrice.ToString();
        //Debug.Log(nameId);
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
