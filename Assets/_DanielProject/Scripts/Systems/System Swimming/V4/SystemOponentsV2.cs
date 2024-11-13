using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemOponentsV2 : MonoBehaviour
{
    [Header("Oponents Settings")]
    public GameObject oponents;
    public float speedMin, speedMax, speed;
    public float X, Y, Z;
    public float rX, rY, rZ;
    public bool isWater;
    public bool start;
    public GameObject timeLine;
    public GameObject render;
    public SystemMainSwimmingV4 swimmin;

    Animator anim;
    bool jumpAnimationPlayed;

    private void Start()
    {
        //render.SetActive(false);
        anim = GetComponent<Animator>();
        jumpAnimationPlayed = false;
    }

    void Update()
    {
        if (start == false && swimmin.gameStart == true && swimmin.isPaused == false)
        {
            if (!jumpAnimationPlayed)
            {
                anim.SetTrigger("Jump");
                jumpAnimationPlayed = true;
            }

            if(jumpAnimationPlayed == true)
            {
                oponents.transform.rotation = Quaternion.Euler(rX, rY, rZ);
                transform.position = transform.position = new Vector3(X, Y, Z);
                timeLine.SetActive(true);
                render.SetActive(true);
                isWater = true;
            }
            
        }

        if (swimmin.isPaused == false && swimmin.gameStart == true && isWater == true)
        {
            anim.SetTrigger("Idle");
            transform.position += Vector3.forward * speed;
            start = true;
        }
    }

    private void LateUpdate()
    {
        speed = Random.Range(speedMin, speedMax);
    }
}
