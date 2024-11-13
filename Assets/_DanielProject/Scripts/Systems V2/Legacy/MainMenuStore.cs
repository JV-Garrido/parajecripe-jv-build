 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStore : MonoBehaviour
{
    public string player01 = "ObjetoX";
    public string player02 = "ObjetoX";
    public string player03 = "ObjetoX";
    public string player04 = "ObjetoX";
    public string player05 = "ObjetoX";
    public string player06 = "ObjetoX";
    public string player07 = "ObjetoX";

    private GameObject spawnedObject;
    private bool trueSpawner = true;

    public GameObject Swimming;
    public GameObject Canoe;
    public GameObject Tennis;
    public GameObject Veronica;
    public GameObject Yohansson;
    public GameObject Terezinha;
    public GameObject SwimmingF;

    public Transform parentTransform;
    public Vector3 spawnPosition; // Posição de spawn do Prefab
    public Vector3 spawnRotation; // Rotação de spawn do Prefab
    public Vector3 spawnScale = Vector3.one; // Escala de spawn do Prefab

    private void Awake()
    {

    }
    private void Start()
    {
       
    }
    private void Update()
    {
        Debug.Log(trueSpawner);
    }
    private void Disable01()
    {
        if (Swimming = GameObject.Find(player01))
        {
            Swimming.SetActive(false);
            trueSpawner = true;
        }
    }
    private void Disable02()
    {
        if (Canoe = GameObject.Find(player02))
        {
            Canoe.SetActive(false);
            trueSpawner = true;
        }
    }
    private void Disable03()
    {
        if (Tennis = GameObject.Find(player03))
        {
            Tennis.SetActive(false);
            trueSpawner = true;
        }
    }
    private void Disable04()
    {
        if (Veronica = GameObject.Find(player04))
        {
            Veronica.SetActive(false);
            trueSpawner = true;
        }
    }
    private void Disable05()
    {
        if (Yohansson = GameObject.Find(player05))
        {
            Yohansson.SetActive(false);
            trueSpawner = true;
        }

    }
    private void Disable06()
    {
        if (SwimmingF = GameObject.Find(player06))
        {
            SwimmingF.SetActive(false);
            trueSpawner = true;
        }

    }
    private void Disable07()
    {
        if (Terezinha = GameObject.Find(player07))
        {
            Terezinha.SetActive(false);
            trueSpawner = true;
        }

    }

    private void OnEnable01()
    {
        if (trueSpawner == true)
        {
            spawnedObject = Instantiate(Swimming, parentTransform);
            spawnedObject.transform.localPosition = spawnPosition;
            spawnedObject.transform.localRotation = Quaternion.identity;
            spawnedObject.transform.localScale = Vector3.one;
            trueSpawner = false;
        }

    }

    public void IsSwimming()
    {

        Disable02();
        Disable03();
        Disable04();
        Disable05();
        Disable06();
        Disable07();
        OnEnable01();

    }
    public void IsCanoe()
    {
        Disable01();
        Disable03();
        Disable04();
        Disable05();
        Disable06();
        Disable07();
    }
    public void IsTennis()
    {
        Disable01();
        Disable02();
        Disable04();
        Disable05();
        Disable06();
        Disable07();
    }
    public void IsVeronica()
    {
        Disable01();
        Disable02();
        Disable03();
        Disable05();
        Disable06();
        Disable07();
    }
    public void IsYohansson()
    {
        Disable01();
        Disable02();
        Disable03();
        Disable04();
        Disable06();
        Disable07();
    }
    public void IsTerezinha()
    {
        Disable01();
        Disable02();
        Disable03();
        Disable04();
        Disable05();
        Disable07();
    }
    public void IsSwimmingF()
    {
        Disable01();
        Disable02();
        Disable03();
        Disable04();
        Disable05();
        Disable06();
    }


}