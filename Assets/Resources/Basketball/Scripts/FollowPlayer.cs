using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador para seguir

    public Vector3 offset = new Vector3(0, 5, -5); // Ajuste a posição da câmera em relação ao jogador

    public float smoothness = 2.0f; // Ajuste a suavidade de movimento da câmera

    public float minZ = -10.0f; // Valor mínimo no eixo Z

    public float maxZ = 10.0f; // Valor máximo no eixo Z

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula a posição desejada da câmera
            Vector3 desiredPosition = player.position + offset;

            // Limita a posição no eixo Z
            desiredPosition.z = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

            // Interpola suavemente a posição atual da câmera em direção à posição desejada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);
        }
    }
}
