using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiGlitchStoreSystemTerezinha : MonoBehaviour
{
    [Header("Terezinha Itens")]
    public GameObject handBandsStandard;
    public GameObject handBands01;
    public GameObject handBands02;
    public GameObject protetoresOcularesStandard;
    public GameObject protetoresOculares01;
    public GameObject protetoresOculares02;
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
                TerezinhaUpdate();
            }
        }
        if (loja == false)
        {
            TerezinhaUpdate();
        }
    }
    void TerezinhaUpdate()
    {
        if(handBands01.activeSelf == true || handBands02.activeSelf == true)
        {
            handBandsStandard.SetActive(false);
        }

        if (handBands01.activeSelf == false && handBands02.activeSelf == false)
        {
            handBandsStandard.SetActive(true);
        }
        //Protetor Ocular
        if (protetoresOculares01.activeSelf == true || protetoresOculares02.activeSelf == true)
        {
            protetoresOcularesStandard.SetActive(false);
        }

        if (protetoresOculares01.activeSelf == false && protetoresOculares02.activeSelf == false)
        {
            protetoresOcularesStandard.SetActive(true);
            
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
