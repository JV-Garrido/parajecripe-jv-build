using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGlitchMabile : MonoBehaviour
{
    public GameObject mobileObject;
    void Start()
    {
#if MOBILE_INPUT
        mobileObject.SetActive(true);
#else
            mobileObject.SetActive(false);
#endif
    }

}
