using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena a ser carregada  
    public Slider progressBar; // Referência ao slider de progresso
    public GameObject panelLoad;
    
    public void LoadScene()
    {
        panelLoad.SetActive(true);
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Progresso entre 0 e 1
            progressBar.value = progress; // Atualiza o valor do slider

            yield return null;
        }
    }
}
