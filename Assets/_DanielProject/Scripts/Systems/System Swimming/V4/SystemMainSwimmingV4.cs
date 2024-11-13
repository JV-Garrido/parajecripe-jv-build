using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SystemMainSwimmingV4 : MonoBehaviour
{
    private static SystemMainSwimmingV4 instance;

    [Header("Player Settings")]
    public GameObject player;
    public GameObject playerParent;
    public bool isPaused;
    public bool gameStart;

    [Header("Oxygen Settings")]
    public Slider oxygenSlider;
    public float maxOxygen = 100f;
    public float currentOxygen;
    public GameObject oxygenWarningObject;
    private bool isBreathing;
    private bool isGameInitialized;

    [Header("Game Over Settings")]
    public GameObject gameOverObject;
    public GameObject withoutOxygen;
    public float gameOverDelay = 15f;
    private bool isGameOver;

    [Header("Victory Settings")]
    public GameObject victoryObject;
    public float victoryDelay = 15f;
    private bool isVictory;

    [Header("Pause Settings")]
    public GameObject pauseObject;

    [Header("Mobile")]
    public GameObject startButton;
    public GameObject oxygenButton;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = currentOxygen;
        oxygenWarningObject.SetActive(false);
        withoutOxygen.SetActive(false);
        gameOverObject.SetActive(false);
        victoryObject.SetActive(false);
        pauseObject.SetActive(false);
    }

    void Update()
    {
        if (isPaused == false)
        {
            if (!gameStart)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                //Mobile
#if MOBILE_INPUT
                if (CrossPlatformInputManager.GetButtonDown("Space"))
                {
                    StartGame();
                    startButton.SetActive(false);
                }
#endif
            }
            else
            {
                UpdateOxygen();

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isBreathing = true;
                    Breathing();
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    isBreathing = false;
                }
                //Mobile
#if MOBILE_INPUT
                if (CrossPlatformInputManager.GetButtonDown("Space"))
                {
                    isBreathing = true;
                    Breathing();
                }

                else if (CrossPlatformInputManager.GetButtonUp("Space"))
                {
                    isBreathing = false;
                }
#endif
                if (currentOxygen <= 0)
                {
                    if (!isGameOver)
                    {
                        //GameOver();
                        GameOverForWithoutOxygen();
                    }
                }

                if (currentOxygen < 35)
                {
                    oxygenWarningObject.SetActive(true);
                    oxygenButton.SetActive(true);
                }
                else
                {
                    oxygenWarningObject.SetActive(false);
                    oxygenButton.SetActive(false);
                }

                if (Input.GetKeyDown(KeyCode.P))
                {
                    PauseGame();
                }
                //Mobile
#if MOBILE_INPUT
                if (CrossPlatformInputManager.GetButtonDown("P"))
                {
                    PauseGame();
                }
#endif
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResumeGame();
            }
            //Mobile
#if MOBILE_INPUT
            if (CrossPlatformInputManager.GetButtonDown("P"))
            {
                ResumeGame();
            }
#endif
        }

        Debug.Log(isVictory);
        Debug.Log(isGameOver);
    }

    void StartGame()
    {
        gameStart = true;
        JumpIntoWater();
    }

    void UpdateOxygen()
    {
        if (!isBreathing)
        {
            currentOxygen -= Time.deltaTime * 3.5f;
        }

        oxygenSlider.value = currentOxygen;
    }

    void Breathing()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.value = currentOxygen;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverObject.SetActive(true);
        isBreathing = false;
        gameStart = false;
        //StartCoroutine(RestartScene(gameOverDelay));
        //RestartSceneV2();
    }
    public void GameOverForWithoutOxygen()
    {
        isGameOver = true;
        withoutOxygen.SetActive(true);
        isBreathing = false;
        gameStart = false;
    }

    public void Victory()
    {
        isVictory = true;
        victoryObject.SetActive(true);
        isBreathing = false;
        gameStart = false;
        //StartCoroutine(RestartScene(victoryDelay));
        //RestartSceneV2();
    }

    void JumpIntoWater()
    {
        player.GetComponent<Animator>().SetBool("jumpp", true);
        playerParent.GetComponentInParent<Animator>().SetTrigger("Jump");
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseObject.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseObject.SetActive(false);
    }

    IEnumerator RestartScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RestartSceneV2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
