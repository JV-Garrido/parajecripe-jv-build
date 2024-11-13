using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blobcreate.ProjectileToolkit;

public class BallSystem : MonoBehaviour
{
    //[SerializeField] TrajectoryPredictor tp;
    [SerializeField] PEBTrajectoryPredictor pTb;
    void Start()
    {
        //pTb.SimulateAndRender();
    }

    // Update is called once per frame
    void Update()
    {
        pTb.SimulateAndRender();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
    }
}
