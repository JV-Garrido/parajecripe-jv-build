using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiGlitchStoreSystemSwimming : MonoBehaviour
{
    [Header("Caps")]
    public GameObject capStandard;
    public GameObject cap01;
    public GameObject cap02;
    public GameObject cap03;
    public GameObject cap04;
    [Header("Controle Loja")]
    public GameObject item;
    public bool loja;
    public string idItem;
    [Header("Aviso Player")]
    public string avisoAntiErros;
    public Text aviso;
    public GameObject avisoPlayer;
    bool result;
    void Start()
    {
        if (loja == true)
        {
            SetHasKey();
            aviso.text = avisoAntiErros;
            StartCoroutine(AntiProblemas());
        }
    }
    void Update()
    {
        if(loja == true)
        {
            SetHasKey();
        }        
    }
    private void LateUpdate()
    {
        if (loja == true)
        {
            if (result == false)
            {
                CapUpdate();
            }
        }
        if(loja == false)
        {
            CapUpdate();
        }
    }
    void CapUpdate()
    {
        if(cap01.activeSelf == false && cap02.activeSelf == false && cap03.activeSelf == false && cap04.activeSelf == false)
        {
            capStandard.SetActive(true);
            if(loja == true)
            {
                //avisoPlayer.SetActive(false);   
            }
             
        }
        if (cap01.activeSelf == !false || cap02.activeSelf == !false || cap03.activeSelf == !false || cap04.activeSelf == !false)
        {
            capStandard.SetActive(false);
            
        }
        if(loja == true)
        {
            if (cap01.activeSelf == true && cap02.activeSelf == true || cap03.activeSelf == true && cap04.activeSelf == true )
            {
                capStandard.SetActive(false);
                avisoPlayer.SetActive(true);
            }
           
        }
    }
    void SetHasKey()
    {
        if (PlayerPrefs.HasKey(idItem))
        {
            result = PlayerPrefs.GetInt(idItem) == 1;
        }
        if(result == true)
        {
            item.SetActive(true);
        }
    }

    IEnumerator AntiProblemas()
    {
        yield return new WaitForSeconds(0.5f);
        avisoPlayer.SetActive(true);
        yield return new WaitForSeconds(60.5f);
        avisoPlayer.SetActive(false);
    }
}
