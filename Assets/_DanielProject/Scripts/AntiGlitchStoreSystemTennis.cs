using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiGlitchStoreSystemTennis : MonoBehaviour
{
    [Header("Raquetes")]
    public GameObject raqueteStandard;
    public GameObject raquete01;
    public GameObject raquete02;
    public GameObject raquete03;
    public GameObject raquete04;
    [Header("Controle Loja")]
    public GameObject item;
    public bool loja;
    public string idItem;
    [Header("Aviso Player")]
    public string avisoAntiErros = "Não equipe múltiplos itens no seu personagem!";
    public Text aviso;
    public GameObject avisoPlayer;
    bool result;
    void Start()
    {
        if(loja == true)
        {
            SetHasKey();
            aviso.text = avisoAntiErros;
            StartCoroutine(AntiProblemas());
        }
    }
    void Update()
    {
        if (loja == true)
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
                RaqueteUpdate();
            }
        }
        if (loja == false)
        {
            RaqueteUpdate();
        }
    }
    void RaqueteUpdate()
    {
        if (raquete01.activeSelf == false && raquete02.activeSelf == false && raquete03.activeSelf == false && raquete04.activeSelf == false)
        {
            raqueteStandard.SetActive(true);
        }
        if (raquete01.activeSelf == true || raquete02.activeSelf == true || raquete03.activeSelf == true || raquete04.activeSelf == true)
        {
            raqueteStandard.SetActive(false);
        }
        
    }
    void SetHasKey()
    {
        if (PlayerPrefs.HasKey(idItem))
        {
            result = PlayerPrefs.GetInt(idItem) == 1;
        }
        if (result == true)
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
