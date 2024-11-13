using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool tutorialOn;
    public BasketBallTutorial ballTutorial;
    public float moveSpeed = 5.0f;  // Velocidade de movimento.
    private CharacterController controller; // Referência ao Character Controller.
    private Animator animator; // Referência ao Animator.
    private float initialYPosition; // Altura inicial do jogador.
    public RotateObjectBasketBall rotateObjectBasketBallL;
    public RotateObjectBasketBall rotateObjectBasketBallR;
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        
        // Capturamos as entradas do jogador.
        float horizontalInput = SimpleInput.GetAxis("Horizontal");
        float verticalInput = SimpleInput.GetAxisRaw("Vertical");

        // Calculamos a direção de movimento com base nas entradas.
        Vector3 moveDirection = new (verticalInput, 0, -horizontalInput);

        if (moveDirection != Vector3.zero)
        {
            // Calculamos a rotação para olhar na direção de movimento.
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);

            // Aplicamos a rotação suavemente usando a função Slerp.
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);

            // Define o parâmetro "Speed" no Animator com base na magnitude da velocidade.
            float speed = moveDirection.magnitude;
             animator.SetFloat("Speed", speed);
            if(speed >= 0.3)
            {
                rotateObjectBasketBallL.rot = true;
                rotateObjectBasketBallR.rot = true;
            }
            if(speed <= 0.3f)
            {
                rotateObjectBasketBallL.rot = false;
                rotateObjectBasketBallR.rot = false;
            }
            if (tutorialOn == true && speed >= 0.1f)
            {
                ballTutorial.startPart02 = true;
                tutorialOn = false;
            }
            Debug.Log(speed);
        }
        else
        {
            // Se o jogador não estiver se movendo, define a velocidade para 0.
            animator.SetFloat("Speed", 0);
            rotateObjectBasketBallL.rot = false;
            rotateObjectBasketBallR.rot = false;
        }
        
        // Mantenha a altura do jogador constante.
        Vector3 newPosition = transform.position;
        newPosition.y = initialYPosition;
        transform.position = newPosition;
        // Aplicamos a velocidade de movimento.
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    
}
