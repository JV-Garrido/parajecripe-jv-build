using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemPlayerV2 : MonoBehaviour
{
    [Header("Player Settings")]
    public bool armStrokesOK;
    public GameObject player;
    public Timer at; //armStrokesTimer

    string lastSide;
    Vector3 movement;
    Vector3 maxvel;

    Vector3 rotationVector;
    void Start()
    {
        maxvel = new Vector3(0.0f, 0.0f, 3);
        movement = new Vector3(0, 0, 11f);
        lastSide = "left";
        rotationVector.x = -90;
        rotationVector.y = 180;
        rotationVector.z = 0;
        
    }


    void Update()
    {
        if (armStrokesOK)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ArmStroke("left", "leftArmStrokeTrigger");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ArmStroke("right", "rightArmStrokeTrigger");
            }

        }
    }
    void ArmStroke(string thisSide, string sideTrigger)
    {
        if (player.GetComponent<Rigidbody>().velocity.z < maxvel.z
            && at.time <= 2f
            && lastSide != thisSide)
        {

            player.GetComponent<Animator>().SetTrigger(sideTrigger);
            MoveForward();
            at.SetTimer();
            lastSide = thisSide;
            
            //rotationVector = player.transform.eulerAngles;

            player.transform.rotation = Quaternion.Euler(rotationVector);

        }
        else
        {
            at.ResetTimer();
        }

    }
    void MoveForward()
    {
        player.GetComponent<Rigidbody>().AddForce(movement * 13);
        Debug.Log(player.GetComponent<Rigidbody>().velocity);
    }
}
