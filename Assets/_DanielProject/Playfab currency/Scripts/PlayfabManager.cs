using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager instance;

    [Header("Other variables")]
    public int coins;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Login();
    }
    private void LateUpdate()
    {
        //Debug.Log(coins);
    }
    // Login
    public void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "Olympic", // Change that to create a new user
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        GetVirtualCurrencies();
    }
    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }
    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        coins = result.VirtualCurrency["PJ"];
    }
    public void GrantVirtualCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "PJ",
            Amount = 50
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }
    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency granted!");
        instance.GetVirtualCurrencies();
    }
    void OnGameStart(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Game started!");
        instance.GetVirtualCurrencies();
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }

}
