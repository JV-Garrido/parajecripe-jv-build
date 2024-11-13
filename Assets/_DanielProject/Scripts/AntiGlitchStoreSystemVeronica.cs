using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiGlitchStoreSystemVeronica : MonoBehaviour
{
    [Header("Veronica Itens")]
    public GameObject headbandStandard;
    public GameObject headband01;
    public GameObject headband02;
    public GameObject headband03;
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
        if (loja == true)
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
                VeronicaUpdate();
            }
        }
        if (loja == false)
        {
            VeronicaUpdate();
        }
    }
    void VeronicaUpdate()
    {
        if (headband01.activeSelf == false && headband02.activeSelf == false && headband03.activeSelf == false)
        {
            headbandStandard.SetActive(true);
        }
        if (headband01.activeSelf == true || headband02.activeSelf == true || headband03.activeSelf == true)
        {
            headbandStandard.SetActive(false);
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
