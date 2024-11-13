using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentacaoNavMesh : MonoBehaviour
{
    public float distanciaAfastamento = 2f; // Distância desejada entre o agente e o jogador
    public float distanciaParar = 1.5f;
    public Animator animator; // Referência ao componente Animator
    public RotateObjectBasketBall rotateObjectBasketBallL;
    public RotateObjectBasketBall rotateObjectBasketBallR;
    private Transform alvo01; // O jogador que o agente deve seguir
    private NavMeshAgent agente; // Referência ao componente NavMeshAgent
    private string nameTag;
    private static MovimentacaoNavMesh movimentacaoNavMesh;
    private void Awake()
    {
        movimentacaoNavMesh = this;
    }
    void Start()
    {
        TargetBall();
        alvo01 = GameObject.FindWithTag(nameTag).transform; // Encontre o jogador com uma tag "Player" (você pode ajustar isso de acordo com o seu projeto)
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Certifique-se de que o componente Animator está presente no GameObject
    }

    void Update()
    {
        if (alvo01 != null)
        {
            // Calcula a direção do agente para o jogador
            Vector3 direcaoParaJogador = alvo01.position - transform.position;

            // Normaliza a direção e multiplica pela distância de afastamento desejada
            Vector3 destinoAfastado = alvo01.position - direcaoParaJogador.normalized * distanciaAfastamento;

            // Configura o destino do agente para a posição afastada do jogador
            agente.SetDestination(destinoAfastado);

            // Verifica se o agente está se movendo
            bool estaSeMovendo = agente.velocity.magnitude > 0.1f;

            // Atualiza o parâmetro "IsRunning" na animação com base no movimento
            animator.SetBool("IsRunning", estaSeMovendo);

            // Verifica se o agente está próximo o suficiente do jogador para parar a animação
            if (agente.remainingDistance <= distanciaParar)
            {
                animator.SetBool("IsRunning", false);
            }
            // Verifica se o alvo é o "Target" e vira o agente para ele
            if (nameTag == "Target")
            {
                // Obtém a direção para o alvo
                Vector3 directionToTarget = alvo01.position - transform.position;
                directionToTarget.y = 0f; // Garante que a rotação seja apenas no plano horizontal

                // Rotaciona o agente para olhar na direção do alvo
                if (directionToTarget != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Ajuste a velocidade da rotação conforme necessário
                }
            }
            if(estaSeMovendo == true) 
            {
                rotateObjectBasketBallL.rot = estaSeMovendo;
                rotateObjectBasketBallR.rot = estaSeMovendo;
            }
            if (estaSeMovendo == false)
            {
                rotateObjectBasketBallL.rot = estaSeMovendo;
                rotateObjectBasketBallR.rot = estaSeMovendo;
            }
        }

    }

    public void TargetPlayer()
    {
        nameTag = "Player";
    }
    public void TargetBall()
    {
        nameTag = "Ball";
    }
    public void Target()
    {
        nameTag = "Target";
    }
}