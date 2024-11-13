using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastVisualizer : MonoBehaviour
{
    public float raycastDistance = 10f;

    void Update()
    {
        // Lança um raycast para frente a partir da posição do objeto que possui este script
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.Log("Raycast atingiu: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
        }
    }
}

