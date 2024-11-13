using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasketballScore : MonoBehaviour
{
    public Text textPoint;
    // Variável para armazenar a pontuação
    private int pontuacao = 0;

    // Método chamado quando algo entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger tem a tag "BolaDeBasquete"
        if (other.CompareTag("BolaDeBasquete"))
        {
            // Incrementa a pontuação
            pontuacao++;

            // Exibe a pontuação no console (você pode substituir isso por sua lógica de exibição)
            Debug.Log("Pontuação de Basquete: " + pontuacao);

            // Você pode adicionar aqui qualquer outra lógica desejada relacionada à pontuação de basquete
        }
    }
    private void Update()
    {
        UpdateTXT();
    }
    private void UpdateTXT()
    {
        textPoint.text=pontuacao.ToString();
    }
}

