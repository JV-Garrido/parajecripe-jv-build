using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregamentoDeCena : MonoBehaviour
{
    public string nomeDaCenaParaCarregar; // Nome da cena a ser carregada
    public float tempoDeAtraso = 2.5f; // Tempo de atraso em segundos
    public GameObject panelLoad;
    private void Awake()
    {
        panelLoad.SetActive(true);
    }
    void Start()
    {
        // Inicia a coroutine para carregar a cena após um pequeno atraso
        StartCoroutine(CarregarCenaComAtraso());
    }

    IEnumerator CarregarCenaComAtraso()
    {
        // Aguarda o tempo de atraso
        yield return new WaitForSeconds(tempoDeAtraso);

        // Carrega a cena usando o nome fornecido
        SceneManager.LoadScene(nomeDaCenaParaCarregar);
    }
}
