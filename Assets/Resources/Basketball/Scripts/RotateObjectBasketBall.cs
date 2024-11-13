using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectBasketBall : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Velocidade de rotação
    public bool rot;
    private static RotateObjectBasketBall rotateObjectBasketBall;
    private void Awake()
    {
        rotateObjectBasketBall = this;
    }
    void Update()
    {
        if(rot == true)
        {
            // Rotaciona o objeto em torno do eixo Z
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Rotaciona o objeto em torno do eixo Z
            transform.Rotate(0, 0, 0);
        }
    }
}
