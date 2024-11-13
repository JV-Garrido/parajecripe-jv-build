using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTutorialCanoagem : MonoBehaviour
{
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    void Start()
    {
        B1.SetActive(false);
        B2.SetActive(false);
        B3.SetActive(false);
        b1.SetActive(false);
        b2.SetActive(false);
        b3.SetActive(false);
    }

}
