using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGlitchItem : MonoBehaviour
{
    [Header("Natação Masculina Item")]
    public GameObject capItemPadrao;
    public GameObject capItem01;
    public GameObject capItem02;
    public GameObject capItem03;
    public GameObject capItem04;
    [Header("Natação Masculina Item")]
    public GameObject capEdeniaItemPadrao;
    public GameObject capEdeniaItem01;
    public GameObject capEdeniaItem02;
    public GameObject capEdeniaItem03;
    public GameObject capEdeniaItem04;
    [Header("Tennis Item")]
    public GameObject raqueteItemPadrao;
    public GameObject raqueteItem01;
    public GameObject raqueteItem02;
    public GameObject raqueteItem03;
    public GameObject raqueteItem04;
    [Header("Veronica Item")]
    public GameObject headbandsItemPadrao;
    public GameObject headbandsItem01;
    public GameObject headbandsItem02;
    public GameObject headbandsItem03;
    [Header("Terezina Item")]
    public GameObject handBandItemPadrao;
    public GameObject handBandItem01;
    public GameObject handBandItem02;
    public GameObject protetorOculaItemPadrao;
    public GameObject protetorOculaItem01;
    public GameObject protetorOculaItem02;

    [Header("Controle")]
    public bool Clodoaldo;
    public bool Edenia;
    public bool Marcos;
    public bool Veronica; 
    public bool Terezinha; 
    void Update()
    {
        if(Clodoaldo == true)
        {
            FixCaps();
        }
        if(Edenia == true)
        {
            FixEdeniaCaps();
        }
        if(Marcos == true)
        {
            FixTennis();
        }
        if(Veronica == true)
        {
            FixVeronica();
        }
    }
    void FixCaps()
    {
        if(capItem01.activeSelf == true)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem02.activeSelf == true)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem03.activeSelf == true)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem04.activeSelf == true)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem03.activeSelf == false && capItem02.activeSelf == false && capItem01.activeSelf == true && capItem04.activeSelf == false)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem03.activeSelf == true && capItem02.activeSelf == false && capItem01.activeSelf == true && capItem04.activeSelf == false)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem03.activeSelf == false && capItem02.activeSelf == true && capItem01.activeSelf == false && capItem04.activeSelf == false)
        {
            capItemPadrao.SetActive(false);
        }
        else if (capItem03.activeSelf == false && capItem02.activeSelf == false && capItem01.activeSelf == false && capItem04.activeSelf == true)
        {
            capItemPadrao.SetActive(false);
        }
        //Padrão
        if (capItem03.activeSelf == false && capItem02.activeSelf == false && capItem01.activeSelf == false && capItem04.activeSelf == false)
        {
            capItemPadrao.SetActive(true);
        }
    }
    void FixEdeniaCaps()
    {
        if (capEdeniaItem01.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem02.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem03.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem04.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem03.activeSelf == false && capEdeniaItem02.activeSelf == false && capEdeniaItem01.activeSelf == true && capEdeniaItem04.activeSelf == false)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem03.activeSelf == false && capEdeniaItem02.activeSelf == false && capEdeniaItem01.activeSelf == false && capEdeniaItem04.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem03.activeSelf == true && capEdeniaItem02.activeSelf == false && capEdeniaItem01.activeSelf == true)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        else if (capEdeniaItem03.activeSelf == false && capEdeniaItem02.activeSelf == true && capEdeniaItem01.activeSelf == false)
        {
            capEdeniaItemPadrao.SetActive(false);
        }
        //Padrão
        if (capEdeniaItem03.activeSelf == false && capEdeniaItem02.activeSelf == false && capEdeniaItem01.activeSelf == false && capEdeniaItem04.activeSelf == false)
        {
            capEdeniaItemPadrao.SetActive(true);
        }
    }
    void FixTennis()
    {
        if(raqueteItem01.activeSelf == true)
        {
            raqueteItemPadrao.SetActive(false);
        }
        else if (raqueteItem02.activeSelf == true)
        {
            raqueteItemPadrao.SetActive(false);
        }
        else if (raqueteItem03.activeSelf == true)
        {
            raqueteItemPadrao.SetActive(false);
        }
        else if (raqueteItem04.activeSelf == true)
        {
            raqueteItemPadrao.SetActive(false);
        }
        else if (raqueteItem04.activeSelf == false && raqueteItem03.activeSelf == false && raqueteItem02.activeSelf == false && raqueteItem01.activeSelf == false)
        {
            raqueteItemPadrao.SetActive(true);
        }
    }
    void FixVeronica()
    {
        if(headbandsItem01.activeSelf == true)
        {
            headbandsItemPadrao.SetActive(false);
        }
        else if (headbandsItem02.activeSelf == true)
        {
            headbandsItemPadrao.SetActive(false);
        }
        else if (headbandsItem03.activeSelf == true)
        {
            headbandsItemPadrao.SetActive(false);
        }
        else if (headbandsItem03.activeSelf == false && headbandsItem02.activeSelf == false && headbandsItem01.activeSelf == false)
        {
            headbandsItemPadrao.SetActive(true);
        }
    }
    void FixTerezinha()
    {
        if(handBandItem01.activeSelf == true)
        {
            handBandItemPadrao.SetActive(false);
        }
        else if (handBandItem02.activeSelf == true)
        {
            handBandItemPadrao.SetActive(false);
        }
        else if (handBandItem02.activeSelf == false && handBandItem01.activeSelf == false)
        {
            handBandItemPadrao.SetActive(true);
        }
        //Protetor
        if (protetorOculaItem01.activeSelf == true)
        {
            protetorOculaItemPadrao.SetActive(false);
        }
        else if (protetorOculaItem02.activeSelf == true)
        {
            protetorOculaItemPadrao.SetActive(false);
        }
        else if (protetorOculaItem01.activeSelf == false && protetorOculaItem02.activeSelf == false)
        {
            protetorOculaItemPadrao.SetActive(true);
        }
    }
}
