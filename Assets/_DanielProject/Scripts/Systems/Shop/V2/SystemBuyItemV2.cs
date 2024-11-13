//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using PlayFab;
//using PlayFab.ClientModels;

//public class SystemBuyItemV2 : MonoBehaviour
//{
//    public PlayfabManager playfabManager;
    
//    [Header("Item Price")]
//    public int princeItem;
//    [Header("Item Objeto")]
//    public GameObject equipItem;
//    public GameObject item;
//    public Color itemColor;
//    public Material newMaterial;
//    public Material currentMaterial;
//    //[Header("ID do item/moeda")]
//    //public string itemID;
//    [Header("Ui Error")]
//    public GameObject uiSetErro;
//    [Header("KeyName setBool")]
//    public string keyName;
//    [Header("This GameObject")]
//    public GameObject thisGameObject;
//    [Header("Add Item?")]
//    public bool addItem;
//    [Header("Other material?")]
//    public bool otherMaterial;
//    int setbool;
//    int coinsPlayer;
//    private void Awake()
//    {
//        setbool = PlayerPrefs.GetInt(keyName);
//        if (otherMaterial == true)
//        {
//            currentMaterial = this.GetComponent<Renderer>().material;
//        } 
//        if (setbool >= 1 && addItem == false)
//        {
//            item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//        }
//        if(setbool >= 1 && addItem == true)
//        {
//            item.SetActive(true);
//            item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//        }
//        if (setbool >= 1 && addItem == false && otherMaterial == true)
//        {
//            //item.SetActive(true);
//            //item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//            currentMaterial = newMaterial;
//        }
//    }
//    private void Start()
//    {
//        if (setbool >= 1)
//        {
//            equipItem.SetActive(true);
//            Debug.Log("foi");
//        }
//        if (setbool >= 1)
//        {
//            thisGameObject.SetActive(false);
//        }
//    }
//    void LateUpdate()
//    {
//        coinsPlayer = playfabManager.coins;
//    }
//    public void BuyItem()
//    {
//        if(coinsPlayer >= princeItem)
//        {
//            var request = new SubtractUserVirtualCurrencyRequest
//            {
//                VirtualCurrency = "PJ",
//                Amount = princeItem
//            };
//            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
//            Debug.Log("Buy item on");
//           // GrantVirtualCurrency();
//        }
//        else
//        {
//            Debug.Log("Buy item off");
//            Debug.Log(coinsPlayer);
//        }
        
//    }
//    void OnError(PlayFabError error)
//    {
//        Debug.Log("Error: " + error.ErrorMessage);
//    }
//    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result)
//    {
//        setbool = 1;
//        PlayerPrefs.SetInt(keyName, setbool);
//        PlayerPrefs.Save();
//        if (setbool >= 1 && addItem == false && otherMaterial == false)
//        {
//            item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//        }
//        if (setbool >= 1 && addItem == true && otherMaterial == false)
//        {
//            item.SetActive(true);
//            item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//        }
//        if (setbool >= 1 && addItem == false && otherMaterial == true)
//        {
//            //item.SetActive(true);
//            //item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//            currentMaterial = newMaterial;
//        }
//        PlayfabManager.instance.GetVirtualCurrencies();
//    }
//    IEnumerator DisableUiError()
//    {
//        yield return new WaitForSeconds(6.5f);
//        uiSetErro.SetActive(false);
//    }
//    //Other
//    public void EquipItem()
//    {
//        if(setbool >= 1)
//        {
//            if (otherMaterial == true)
//            {
//                currentMaterial = this.GetComponent<Renderer>().material;
//            }
//            setbool = PlayerPrefs.GetInt(keyName);
//            if (setbool >= 1 && addItem == false)
//            {
//                item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//            }
//            if (setbool >= 1 && addItem == true)
//            {
//                item.SetActive(true);
//                item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//            }
//            if (setbool >= 1 && addItem == false && otherMaterial == true)
//            {
//                //item.SetActive(true);
//                //item.GetComponent<Renderer>().material.SetColor("_EmissionColor", itemColor);
//                currentMaterial = newMaterial;
//            }
//        }
//    }
//}
