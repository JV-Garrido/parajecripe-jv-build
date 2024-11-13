using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Velocidade de rotação do objeto

    // Rotacionar o objeto para a esquerda
    public void RotateLeft()
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
    }

    // Rotacionar o objeto para a direita
    public void RotateRight()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
