using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManagerBasketball : MonoBehaviour
{
    public AudioManagerBasketball audioManagerBasketball;
    public bool onTutorial;
    public BasketBallTutorial basketBallTutorial;
    public bool enemy;
    public Text textScore;
    public Text textScoreEnemy;
    public int score = 0; // Inicializa a pontuação em zero
    public int scoreEnemy = 0; // Inicializa a pontuação em zero
    private static ScoreManagerBasketball scoreManager;
    private void Awake()
    {
        scoreManager = this;
    }
    void Start()
    {
        score = 0; // Certifica-se de que a pontuação seja zero no início
    }
    private void Update()
    {
        if(onTutorial == false) {
            textScore.text = score.ToString();
            textScoreEnemy.text = scoreEnemy.ToString();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && enemy == false)
        {
            // Se a colisão for com um objeto que tem a tag "Ball", aumente a pontuação
            score++;
            audioManagerBasketball.PlayAudio2();
            if (onTutorial && score > 0)
            {
                basketBallTutorial.startPart03 = false;
                basketBallTutorial.startPart04 = true;

            }
            Debug.Log("Pontuação: " + score); // Exibe a pontuação no console (opcional)
        }
        if (collision.gameObject.CompareTag("Ball") && enemy == true && enemy == !false)
        {
            // Se a colisão for com um objeto que tem a tag "Ball", aumente a pontuação
            scoreEnemy++;
            Debug.Log("Pontuação: " + score); // Exibe a pontuação no console (opcional)
        }
    }
}
