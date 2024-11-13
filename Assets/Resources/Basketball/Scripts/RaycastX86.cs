using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastX86 : MonoBehaviour
{
    public bool ingame;   
    public GameObject jogarBola;
    public GameObject jogarBola2;
    public float raycastDistance;
    public string targetTag = "X"; 
    public ThrowObject throwObject;
    public GetBall getBall;
    public string objectName;
    public bool controle;
    GameObject obj;
    bool vai;

    private void Awake()
    {
        obj = GameObject.Find(objectName);
        throwObject = obj.GetComponent<ThrowObject>();
    }
    private void Start()
    {
        StartCoroutine(GetBaloObj());
        throwObject = obj.GetComponent<ThrowObject>();
        obj = GameObject.Find(objectName);
    }
    void Update()
    {
        if(obj.activeSelf == true)
        {
            controle = throwObject.observe;
            // Crie um raio na direção para a frente do objeto
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; // Armazena informações sobre a colisão

            // Realize o Raycast
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
                    throwObject.observe = true;                    
#if MOBILE_INPUT
                    if (ingame == true)
                    {
                        jogarBola.SetActive(true);
                        jogarBola2.SetActive(false);
                    }
#else
            if (ingame == true){
            getBall.onArremesso=true;
            }
            
#endif
                }

                if (!hit.collider.CompareTag(targetTag))
                {
                    Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
#if MOBILE_INPUT
                    if (ingame == true)
                    {
                        jogarBola.SetActive(false);
                        jogarBola2.SetActive(true);
                    }
#else
                    if (ingame == true)
                    {
                    getBall.onArremesso=false;
                    }
                    
            
#endif

                }

            }
        }
        
    }

    IEnumerator GetBaloObj()
    {
        yield return new WaitForSeconds(1.5f);
        throwObject = obj.GetComponent<ThrowObject>();
        vai = true;
    }
}

