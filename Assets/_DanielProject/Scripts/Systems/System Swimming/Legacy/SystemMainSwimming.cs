using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SystemMainSwimming : MonoBehaviour
{
    private static SystemMainSwimming instance;
    [Header("Game manager")]
    public Transform one, two, three;
    public int coinsPlayer;
    public bool startGame;
    public bool pauseGame;
    public bool setGameOver;
    public bool setShowWin;
    [Header("Game Settings")]
    public PlayfabManager playfabManager;
    public SystemPlayer systemPlayer;
    public SystemPlayerV3 systemPlayerV3;
    public int timeGame;
    public float oxygenPlayer;
    public string sceneName;
    public GameObject player;
    public GameObject playerParent;
    public SwimmingTutorial_Player swimmingTutorial_Player;
    [Header("UI Settings")]
    //Panels
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    //Warnings
    public GameObject avisoOxygen;
    public GameObject avisoStart;
    //Texts
    public Text coinsText;
    public Text currentPositionTXT;
    public Text currentPositionTXTinGame;
    //Others
    public Slider oxygenPlayerBar;
    [Header("Position Player")]
    public int positionPlayer;
    public bool winPlayer;
    public bool fimDeJogo;
    [Header("Game Audio")]
    public AudioSource backAudio;
    public AudioSource isWaterAudio;
    public AudioSource applauseAudio;
    public AudioSource fxSwimming;
    public AudioSource fxOxygen;
    void Awake()
    {
        GetFx();
        instance = this;
    }
    void Start()
    {
        GetFx();
        startGame = false;
        pauseGame = false;
    }
    void Update()
    {
        coinsText.text = playfabManager.coins.ToString();

        //Start Game
        GameStart();
        Debug.Log(startGame);
        //Oxygen Player
        GrantOxygen();
        //Pause
        PauseGamePlay();
        if (pauseGame == true && fimDeJogo == false)
        {
            pausePanel.SetActive(true);
        }
        if (pauseGame == false)
        {
            pausePanel.SetActive(false);
        }
    }
    void LateUpdate()
    {
        
        if (startGame == true && pauseGame == false)
        {
            //backAudio.Play();
            fxSwimming.Play();
            timeGame--;
            //Reduces oxygen
            oxygenPlayer--;
            oxygenPlayerBar.value = oxygenPlayer;
            if(oxygenPlayer <= 0)
            {
                GameOver();
            }
            if (oxygenPlayer <= 345)
            {
                avisoOxygen.SetActive(true);
            }
            if (oxygenPlayer >= 345)
            {
                avisoOxygen.SetActive(false);
            }
            //Position Player
            PositionPlayerGame();
            coinsPlayer = playfabManager.coins;
        }
    }
    //Mute
    public void Mute()
    {
        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }
    //Grant oxygen
    public void GrantOxygen()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fxOxygen.Play();
            oxygenPlayer = 685;
        }
        
    }
    //Start Game
    public void GameStart()
    {
        if(startGame == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                startGame = true;
                avisoStart.SetActive(false);
                systemPlayer.WaterPlayer();
                systemPlayerV3.WaterPlayer();
                swimmingTutorial_Player.armStrokesOK = true;
                JumpIntoWater();
                isWaterAudio.Play();
                backAudio.Play();
            }
        }
        
    }
    void JumpIntoWater()
    {
        player.GetComponent<Animator>().SetBool("jumpp", true);
        playerParent.GetComponentInParent<Animator>().SetTrigger("Jump");
    }
    //GameOver
    public void GameOver()
    {
        applauseAudio.Play();
        fxSwimming.mute = true;
        gameOverPanel.SetActive(true);
    }
    //Show Win
    public void ShowWin()
    {
        applauseAudio.Play();
        fxSwimming.mute = true;
        winPlayer = true;
        winPanel.SetActive(true);
        Debug.Log("Show Win");
    }
    //Pause Game
    public void PauseGamePlay()
    {
        if (Input.GetKey(KeyCode.P))
        {
            pauseGame = true;
            avisoStart.SetActive(false);
            MuteAll();
        }
        if (startGame == true)
        {
            avisoStart.SetActive(false);
        }
    }
    public void ExitPauseGamePlay()
    {
        if(startGame == false)
        {
            avisoStart.SetActive(true);
        }
        pauseGame = false;
    }
    //Try again
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Menu
    public void Menu()
    {
        SceneManager.LoadScene(sceneName);
    }
    //Position
    public void PositionPlayerGame()
    {
        if(positionPlayer == 1 && winPlayer == true && timeGame <= 0)
        {
            ShowWin();
            GrantPlayerOne();
            currentPositionTXT.text = positionPlayer.ToString();
        }
        if (positionPlayer >= 2 && winPlayer == true && timeGame <= 0)
        {
            currentPositionTXT.text = positionPlayer.ToString();
            if(positionPlayer == 2)
            {
                GameOver();
                GrantPlayerTwo();
            }
            if (positionPlayer >= 2)
            {
                GameOver();
                GrantPlayerThree();
            }
        }
        if (positionPlayer >= 2 && winPlayer == false && timeGame <= 0)
        {
            currentPositionTXT.text = positionPlayer.ToString();
            if (positionPlayer == 2)
            {
                GameOver();
                GrantPlayerTwo();
            }
            if (positionPlayer >= 2)
            {
                GameOver();
                GrantPlayerThree();
            }
        }
        if (one.position.z >= two.position.z && one.position.z >= three.position.z)
        {
            positionPlayer = 1;
            Debug.Log("1");
        }
        else if (one.position.z <= two.position.z && one.position.z >= three.position.z || one.position.z >= two.position.z && one.position.z <= three.position.z)
        {
            positionPlayer = 2;
            Debug.Log("2");
        }
        else if (one.position.z <= two.position.z && one.position.z <= three.position.z)
        {
            Debug.Log("3");
            positionPlayer = 3;
        }
        Debug.Log(positionPlayer);
        currentPositionTXTinGame.text = positionPlayer.ToString();
    }
    //Playfab Grant
    public void GrantPlayerOne()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "PJ",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }
    public void GrantPlayerTwo()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "PJ",
            Amount = 5
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }
    public void GrantPlayerThree()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "PJ",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }
    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        fimDeJogo = true;
        pauseGame = true;
        Debug.Log("Currency granted!");
        playfabManager.GetVirtualCurrencies();
    }
    void OnError(PlayFabError error)
    {
       // Debug.Log("Error: " + error.ErrorMessage);
    }
    //Audio
    public void MuteAll()
    {
        backAudio.mute = true;
        isWaterAudio.mute = true;
        applauseAudio.mute = true;
        fxSwimming.mute = true;
        fxOxygen.mute = true;
    }
    public void GetFx()
    {
        //backAudio = GetComponent<AudioSource>();
        //isWaterAudio = GetComponent<AudioSource>();
        //applauseAudio = GetComponent<AudioSource>();
        //fxSwimming = GetComponent<AudioSource>();
        //fxOxygen = GetComponent<AudioSource>();
    }
}
