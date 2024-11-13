using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGlitchStoreSystemCanoe : MonoBehaviour
{
    [Header("Kayaks")]
    public GameObject canoekayak01;
    public GameObject canoekayak02;
    public GameObject canoekayak03;
    public GameObject canoekayak04;
    [Header("Paddles")]
    public GameObject canoePaddle01;
    public GameObject canoePaddle02;
    public GameObject canoePaddle03;
    [Header("Ativo/Inativo")]
    public bool kayakMode;
    public bool PaddleMode;
    void Update()
    {
        if(kayakMode == true)
        {
            kayakUpdate();
        }
        if(PaddleMode == true)
        {
            PaddleUpdate();
        }
    }
    void kayakUpdate()
    {
        // Item inativo
        if(canoekayak02.activeSelf == false && canoekayak03.activeSelf == false && canoekayak04.activeSelf == false)
        {
            canoekayak01.SetActive(true);
        }
        else if(canoekayak02.activeSelf == false || canoekayak03.activeSelf == false || canoekayak04.activeSelf == false)
        {
            canoekayak01.SetActive(false);
        }
        
        //Item ativo
        if(canoekayak02.activeSelf == true && canoekayak03.activeSelf == true && canoekayak04.activeSelf == true)
        {
            canoekayak01.SetActive(false);
        }
        else if(canoekayak02.activeSelf == true || canoekayak03.activeSelf == true || canoekayak04.activeSelf == true)
        {
            canoekayak01.SetActive(false);
        }
        else if(canoekayak02.activeSelf == true)
        {
            canoekayak01.SetActive(false);
        }
        else if (canoekayak03.activeSelf == true)
        {
            canoekayak01.SetActive(false);
        }
    }
    void PaddleUpdate()
    {
        if(canoePaddle02.activeSelf == true)
        {
            canoePaddle01.SetActive(false);
            canoePaddle03.SetActive(false);
        }
        if(canoePaddle03.activeSelf == true)
        {
            canoePaddle01.SetActive(false);
            canoePaddle02.SetActive(false);
        }
        else if(canoePaddle03.activeSelf == true || canoePaddle02.activeSelf == true)
        {
            canoePaddle01.SetActive(false);
        }
        else if (canoePaddle03.activeSelf == false && canoePaddle02.activeSelf == true)
        {
            canoePaddle01.SetActive(false);
        }
        else if (canoePaddle03.activeSelf == true && canoePaddle02.activeSelf == false)
        {
            canoePaddle01.SetActive(false);
        }
        //Padrão ativo
        else if(canoePaddle03.activeSelf == false && canoePaddle02.activeSelf == false)
        {
            canoePaddle01.SetActive(true);
        }
        else if (canoePaddle03.activeSelf == false || canoePaddle02.activeSelf == false)
        {
            canoePaddle01.SetActive(true);
        }

    }
}
