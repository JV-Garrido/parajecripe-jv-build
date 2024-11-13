using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasketballMainSystem : MonoBehaviour
{
    //PRIVATES
    private bool isPaused = false;
    private bool isMuted = false;
    //PUBLIC
    [Header("Voltar ao Menu")]
    public string sceneNameMenu;
    [Header("Manager Score")]
    public ScoreManagerBasketball sM1;
    public ScoreManagerBasketball sM2;
    [Header("Manager Game")]
    public bool isWinner;
    public bool isGameOver;
    public int premioValue;
    public int coinValue;
    [Header("Audio Manager")]
    public AudioManagerBasketball audioManagerBasketball;
    [Header("UI manager")]
    public GameObject[] disableUi;
    public GameObject[] anableUi;
    public GameObject gameOverPanel;
    public GameObject winnerPanel;
    public GameObject pausePanel;
    public Text textGameOver;
    public Text textWinner;
    //public Text textPause;
    public Text textCoinCorrentValue;   
    [Header("CoinManager")]
    public CoinManager coinManager;
    [Header("Tutorial")]
    public bool onTutorial;
    void Start()
    {
        DisableGameObjects(disableUi);
        AnableGameObjects(anableUi);
        if(onTutorial == false)
        {
            textCoinCorrentValue.text = coinManager.GetCoins().ToString();
        }
       
    }

    void Update()
    {
        if (SimpleInput.GetKeyDown(KeyCode.P) && isWinner == false && isGameOver == false)
        {
            if (isPaused)
            {
                ResumeGame();
                pausePanel.SetActive(false);
            }
            else
            {
                PauseGame();
                pausePanel.SetActive(true);
            }
        }
        if (SimpleInput.GetKeyDown(KeyCode.M))
        {
            ToggleMute();
        }
        if(sM1.score >= 3 && isWinner == false && isGameOver == false)
        {
            PauseGame();
            Winner();
        }
        if(sM1.scoreEnemy >= 3 && isWinner == false && isGameOver == false)
        {
            PauseGame();
            GameOver();
        }
    }
    //Pause System
    void PauseGame()
    {
        Time.timeScale = 0; // Pausa o tempo do jogo
        isPaused = true;
        //textPause.text = "É hora de uma pausa no jogo!\nUse P ou o botão < para sair do Pause.\nUse M ou o botão na tela para deixar o jogo mudo.";
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Retoma o tempo do jogo para o valor normal
        isPaused = false;
    }
    //Jogar novamente System
    public void ReloadScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
        SceneManager.LoadScene("PlayBasquete");
    }
    //Sair do game
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(sceneNameMenu); // Troque "MainMenu" pelo nome da cena do seu menu inicial
    }
    //Mute
    void ToggleMute()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0 : 1; // Define o volume global do jogo para 0 quando mudo
    }
    //GameOver
    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        textGameOver.text = "Game Over!!\nInfelizmente, a vitória escapou por entre os dedos, mas lembre-se, o basquete é um jogo de altos e baixos.\nA próxima partida será a oportunidade perfeita para se redimir.";
        audioManagerBasketball.PlayAudio3();
    }
    //Winner
    void Winner()
    {
        isWinner = true;
        winnerPanel.SetActive(true);
        coinManager.AddCoins(premioValue);
        coinValue = premioValue;
        textWinner.text = "Parabéns, jogador! Sua dedicação, habilidade e esforço realmente brilharam durante o jogo.\nVocê ganhou " + coinValue.ToString() + " moedas.";
        audioManagerBasketball.PlayAudio3();
    }
    //UI manager
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
    void AnableGameObjects(GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(true);

            }

        }
    }
}
