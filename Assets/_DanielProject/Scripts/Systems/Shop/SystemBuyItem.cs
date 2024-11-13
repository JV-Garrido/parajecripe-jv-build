//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using PlayFab;
//using PlayFab.ClientModels;

//public class SystemBuyItem : MonoBehaviour
//{
//    private PlayfabManager playfabManager;

//    [Header("UI")]
//    public GameObject uiSetErro;
//    [Header("Buy Settings")]
//    public GameObject thisGameObject;
//    public int itemPrice;
//    public string itemID;
//    public string nameKeyitem;

   

//    int coinsPlayer;

//    int setBuyItem;

//    private void Awake()
//    {
//        coinsPlayer = playfabManager.coins;
//        setBuyItem = PlayerPrefs.GetInt(nameKeyitem);
//    }
//    void Start()
//    {
//        if(setBuyItem == 1)
//        {
//            thisGameObject.SetActive(false);
//        }
//    }
//    public void BuyItem()
//    {
//        if (coinsPlayer >= itemPrice)
//        {
//            var request = new SubtractUserVirtualCurrencyRequest
//            {
//                VirtualCurrency = "OL",
//                Amount = itemPrice
//            };
//            PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
//            GrantVirtualCurrency();
//            setBuyItem = 1;
//            PlayerPrefs.SetInt(nameKeyitem, setBuyItem);
//            PlayerPrefs.Save();
//            StartCoroutine(DisableThisObject());
//        }
//        else
//            uiSetErro.SetActive(true);
//        StartCoroutine(DisableUiError());

//    }

//    //Grant
//    public void GrantVirtualCurrency()
//    {
//        var request = new AddUserVirtualCurrencyRequest
//        {
//            VirtualCurrency = itemID,
//            Amount = 1
//        };
//        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
//    }
//    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
//    {
//        Debug.Log("Currency granted!");
//    }
//    // Other
//    void OnError(PlayFabError error)
//    {
//        Debug.Log("Error: " + error.ErrorMessage);
//    }
//    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result)
//    {
//        PlayfabManager.instance.GetVirtualCurrencies();
//    }
//    IEnumerator DisableUiError()
//    {
//        yield return new WaitForSeconds(6.5f);
//        uiSetErro.SetActive(false);
//    }
//    IEnumerator DisableThisObject()
//    {
//        yield return new WaitForSeconds(3.5f);
//        thisGameObject.SetActive(false);
//    }
//}
