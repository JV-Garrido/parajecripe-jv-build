using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BasketBallTutorial : MonoBehaviour
{
    private static BasketBallTutorial instance;
    [Header("All Objects")]
    public GameObject[] allObjects;
    [Header("Start Tutorial")]
    public bool start;
    public GameObject[] allStart;
    public GameObject startObj;
    [Header("Part01 Tutorial")]
    public Text textPart01;
    public GameObject[] objPart01;
    [Header("Part02 Tutorial")]
    public bool startPart02;
    public Text textPart02;
    public GameObject[] allPart02;
    public GameObject[] objPart02;
    [Header("Part03 Tutorial")]
    public bool startPart03;
    public GameObject[] allPart03;
    public GameObject[] objPart03;
    public Text textPart03;
    public GameObject b1Off;
    public GameObject b2Off;
    [Header("Part04 Tutorial")]
    public bool startPart04;
    public GameObject[] allPart04;
    public GameObject[] objPart04;
    public Text textPart04;
    [Header("Part05 Tutorial")]
    public bool startPart05;
    public string sceneName;
    public GameObject fim;
    private void Awake()
    {
      instance = this;
        DisableGameObjects(allObjects);
        start = true;
    }
    void Start()
    {
         
    }
    void Update()
    {
        //if(startPart03 == true)
        //{
        //    startPart02 = false;
        //}
        if (start && startPart02 == true)
        {
            StartCoroutine(Part02());            
        }
        if (start && startPart02 == false && startPart03 == true)
        {
            StartCoroutine(Part03());                        
        }
        if (start && startPart02 == false && startPart03 == false && startPart04 == true)
        {
            StartCoroutine(Part04());
            DisableGameObjects(objPart03);
            startPart03 = false;
        }
        if (start && startPart02 == false && startPart03 == false && startPart04 == false && startPart05 == true) 
        {
            StartCoroutine(Part05());          
        }
    }
    public void OnStart()
    {
        if (start == true) {
            StartCoroutine(Part01());
            startObj.SetActive(false);
        }
        Debug.Log("Start Tutorial");
    }
    IEnumerator Part01()
    {
        yield return new WaitForSeconds(1f);
        EnableGameObjects(allStart);
#if MOBILE_INPUT
        textPart01.text = "Use o Joystick para se mover.";
#else
           textPart01.text = "Utilize as teclas W, A, S, D ou as SETAS do teclado para movimentar-se.";
#endif
    }
    IEnumerator Part02()
    {
        yield return new WaitForSeconds(5f);
        EnableGameObjects(allPart02);
        DisableGameObjects(objPart01);        
#if MOBILE_INPUT
        textPart02.text = "Pressione o botão em formato de bola para pegar a bola.\nDica: Fique perto da bola.";
#else
           textPart02.text = "Utilize a tecla G para pegar a bola.\nDica: Fique perto da bola.";
#endif
    }
    IEnumerator Part03()
    {
        yield return new WaitForSeconds(1.5f);
        EnableGameObjects(allPart03);
        DisableGameObjects(objPart02);
#if MOBILE_INPUT
        textPart03.text = "Pressione o botão em formato de cesta para lançar a bola.\nDica: Fique de frente para a cesta.";
#else
           textPart03.text = "Utilize a tecla espaço para lançar a bola.\nDica: Fique de frente para a cesta.";
#endif
        yield return new WaitForSeconds(4f);
        b1Off.SetActive(false);
    }
    IEnumerator Part04()
    {
        yield return new WaitForSeconds(0.1f);
        EnableGameObjects(allPart04);
        DisableGameObjects(objPart03);
        startPart05 = true;
        startPart04 = false;
        b2Off.SetActive(false);
#if MOBILE_INPUT
        textPart04.text = "Dica: Não deixe o Oponente se aproximar,\n pois ele pode pegar a bola de você.\n Quem marcar 3 pontos primeiro vence.\n Boa Sorte!";
#else
           textPart04.text = "Dica: Não deixe o Oponente se aproximar,\n pois ele pode pegar a bola de você.\n Quem marcar 3 pontos primeiro vence.\n Boa Sorte!";
#endif
    }
    IEnumerator Part05()
    {
        yield return new WaitForSeconds(10f);
        fim.SetActive(true);
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(sceneName);
        
    }
    void DisableGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(false);

            }

        }
    }
    void EnableGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(true);

            }

        }
    }
    public void Sair()
    {
        SceneManager.LoadScene(sceneName);
    }
}

