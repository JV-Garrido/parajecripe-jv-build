using Blobcreate.ProjectileToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public bool onTutorial;
    public BasketBallTutorial basketBallTutorial;
    public ScoreManagerBasketball scoreManager;
    public Transform pontoB; // Objeto ou posição para B
    public Transform pontoC; // Objeto ou posição para C
    public Transform pontoD; // Objeto ou posição para D
    public Transform pontoE; // Objeto ou posição para E
    public Transform pontoF; // Objeto ou posição para F
    public Transform pontoG; // Objeto ou posição para G
    public Transform pontoH; // Objeto ou posição para H
    public Transform pontoI; // Objeto ou posição para I
    public Transform pontoJ; // Objeto ou posição para J
    public Transform pontoK; // Objeto ou posição para K
    public Transform pontoL; // Objeto ou posição para L
    public Transform pontoM; // Objeto ou posição para M
    public Transform pontoN; // Objeto ou posição para N
    public Transform pontoO; // Objeto ou posição para O
    public Transform pontoP; // Objeto ou posição para P
    public Rigidbody rb; // Rigidbody do objeto
    [Header("Audio Manager")]
    public AudioManagerBasketball audioManagerBasketball;

    private static ThrowObject throwObject;
    private Transform destino; // Próximo destino
    public bool podeMover = false;
    public ScoreManagerBasketball sM;
    public bool observe;

    private void Awake()
    {
        throwObject = this;       
    }

    private void Start()
    {
        EscolherProximoDestino();
    }

    private void Update()
    {
        
        if (podeMover)
        {
            // Move o objeto em direção ao destino escolhido
            float velocidade = 5.0f; // Velocidade de movimento (ajuste conforme necessário)
            transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidade * Time.deltaTime);

            // Verifica se o objeto chegou ao destino
            if (Vector3.Distance(transform.position, destino.position) < 0.01f)
            {
                ChegouAoDestino();
            }
            
        }

        
    }
    
    private void ChegouAoDestino()
    {
        // Desativa o Rigidbody kinematic quando o objeto chegar ao destino
        rb.isKinematic = false;

        // O objeto já chegou ao destino e não se move mais
        podeMover = false;

        // Verifique se o destino atual é pontoB e chame a função GrantScore
        if (destino == pontoB)
        {
            GrantScore();
        }

        //Proximo destino
        EscolherProximoDestino();
    }

    public void IniciarMovimento()
    {
        // Ativa o movimento do objeto
        podeMover = true;
    }

    public void EscolherProximoDestino()
    {
        // Gera um número aleatório para escolher o próximo destino (B, C ou D)
        int randomDestino = Random.Range(1, 15); // Números de 1 a 8

        switch (randomDestino)
        {
            case 1:
                destino = pontoB;
                break;
            case 2:
                destino = pontoC;
                break;
            case 3:
                destino = pontoD;
                break;
            case 4:
                destino = pontoE;
                break;
            case 5:
                destino = pontoF;
                break;
            case 6:
                destino = pontoG;
                break;
            case 7:
                destino = pontoH;
                break;
            case 8:
                destino = pontoI;
                break;
            case 9:
                destino = pontoJ;
                break;
            case 10:
                destino = pontoK;
                break;
            case 11:
                destino = pontoL;
                break;
            case 12:
                destino = pontoM;
                break;
            case 13:
                destino = pontoN;
                break;
            case 14:
                destino = pontoO;
                break;
            case 15:
                destino = pontoP;
                break;
        }
    }
    private void GrantScore()
    {
        Debug.Log("Score granted for reaching point B!");
        audioManagerBasketball.PlayAudio2();
        if (scoreManager.enemy==false) { sM.score++; }
        if (scoreManager.enemy == true) { sM.scoreEnemy++; }
        if (onTutorial)
        {
            basketBallTutorial.startPart03 = false;
            basketBallTutorial.startPart04 = true;
        }
        
    }
    
}


