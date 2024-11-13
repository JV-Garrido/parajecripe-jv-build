using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayerV3 : MonoBehaviour
{
    private static SystemPlayerV3 instance;
    [Header("Player Settings")]
    public GameObject player;
    public float speed;
    public bool isR;
    public bool isL;
    [Header("Others")]
    public Animator anim;
    public SystemMainSwimming systemMain;
    public bool fimdogame;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(systemMain.pauseGame == false && systemMain.startGame == true)
        {
            if(isL == true)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += Vector3.forward * speed;
                    anim.SetBool("isL", true);
                }
                else
                {
                    anim.SetBool("isL",false);
                }
            }
            if(isR == true)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += Vector3.forward * speed;
                    anim.SetBool("isR", true);
                }
                else
                {
                    anim.SetBool("isR", false);
                }
            }
            if (fimdogame == true)
            {
                systemMain.winPlayer = true;
            }
        }
    }
    public void WaterPlayer()
    {
        player.transform.rotation = Quaternion.Euler(-90, 180, 0);
        transform.position = transform.position = new Vector3(0, -1.8f, 6);        
    }
    // Win && R or L
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Win"))
        {
            //Debug.Log("Win");
            Debug.Log(fimdogame);
            systemMain.winPlayer = true;
            systemMain.ShowWin();
            fimdogame = true;

        }
        //R
        if (other.CompareTag("R"))
        {
          Debug.Log("R");
            isR = true;
            isL = false;
            anim.SetBool("isL", false);
        }
        //L
        if (other.CompareTag("L"))
        {
            Debug.Log("L");
            isR = false;
            isL = true;
            anim.SetBool("isR", false);
        }
    }
    

}
