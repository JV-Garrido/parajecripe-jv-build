using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SystemPlayer : MonoBehaviour
{
    private static SystemPlayer instance;

    [Header("Player Settings")]
    public GameObject player;
    public float speed;
    [Header("Others")]
    public Animator anim;
    public bool isWater;
    public GameObject fimDeJogo;
    //[Header("TimeLine System")]
    //public PlayableDirector directorL;
    //public PlayableDirector directorR;
    //public bool lOrR;

    int timeAnim;
    bool R;
    bool L;
    bool setAnim;
    public SystemMainSwimming systemMain;
    bool fimdogame;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Awake()
    {
        timeAnim = 15;
        //TimeLinesOff();
        instance = this;
    }
    private void FixedUpdate()
    {
        //Move player
        if(systemMain.pauseGame == false && systemMain.startGame == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && L == true)
            {
                transform.position += Vector3.forward * speed;
                R = true;
                //anim.SetInteger("setInt", 1);
                //timeAnim--;
                //anim.SetInteger("setInt", 1);                
            }
            //else if(Input.GetKeyUp(KeyCode.LeftArrow) && timeAnim < 0)
            //{
            //    //transform.position -= Vector3.forward * speed*Time.deltaTime;
            //    //transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
            //    //anim.SetInteger("setInt", 0);
            //    timeAnim = 15;
            //}
            //else if(Input.GetKeyUp(KeyCode.RightArrow) && timeAnim < 0)
            //{
            //    //transform.position -= Vector3.forward * speed * Time.deltaTime;
            //    //transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
            //    //anim.SetInteger("setInt", 0);
            //    timeAnim = 15; 
            //}
            if (Input.GetKey(KeyCode.RightArrow) && R == true)
            {
                transform.position += Vector3.forward * speed;
                L = true;
                //anim.SetInteger("setInt", 2);
                //timeAnim--;
                //setAnim = true;
                //transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);
                //anim.SetInteger("setInt", 2);
            }
            else
            {
                //anim.SetInteger("setInt", 0);
            }
            if (fimdogame == true)
            {
                systemMain.winPlayer = true;
            }
            isWater = true;
            Debug.Log(timeAnim);
            
        } 
    }
    private void Update()
    {
        ControllerAnim();
    }
    private void LateUpdate()
    {
        if(L == true)
        {
            R = false;
        }

        if(L == false)
        {
            R = true;
        }
    }
    public void WaterPlayer()
    {
        player.transform.rotation = Quaternion.Euler(-90, 180, 0);
        transform.position = transform.position = new Vector3(0, -1.8f, 6);
        //anim.SetInteger("setInt", 3);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Win"))
        {
            //Debug.Log("Win");
            Debug.Log(fimdogame);
            systemMain.winPlayer = true;
            systemMain.ShowWin();
            fimDeJogo.SetActive(true);
            fimdogame = true;
            
        }
    }
    //TimeLine
    //public void StartTimeLineL()
    //{
    //    directorL.Play();
    //    directorR.Pause();
    //}
    //public void StartTimeLineR()
    //{
    //    directorL.Pause();
    //    directorR.Play();
    //}
    //public void TimeLinesOff()
    //{
    //    directorL.Pause();
    //    directorR.Pause();
    //}
    private void ControllerAnim()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
           anim.SetInteger("setInt", 1);
           Debug.Log("L");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetInteger("setInt", 2);
            Debug.Log("R");
        }
        else
        {
            anim.SetInteger("setInt", 0);
        }
    }
}
