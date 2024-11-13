using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class veronica_Behaviour : MonoBehaviour
{
    public VibrationController vibrationController;
    public CoinManager coinManager;
    public int premioOuro, premioPrata, premioBronze;
    public Text getCoins;

  
    public bool isTutorial;
    private bool start;
    private bool canRun;
    private bool canJump;
    private bool isJumping;
    private bool betweenJumps;
    private bool pressLeft;
    private bool jumpFailed;
    private Animator animator;
    public Rigidbody rb;
    public float acceleration, maxSpeed;
    private float timer;
    public GameObject rightFoot, leftFoot;
    private float jumpDistance;
    public Transform invalid_jump, jump_reference;
    private int jumpNumber;
    private int points;
    public Text pointsText;
    public GameObject jumpMessage;
    public GameObject betweenJumpsWindow;
    public Text betweenJumpsText;
    private string defaultText;
    public GameObject jumpFailedMessage;
    public GameObject resultCanvas;
    public Text resultText;
    private float[] personalScore;
    private string[] adversaryNames;
    private float[] scoreBoard;
    private string[] scoreBoardNames;
    private StoreDataContainer sD;
    LongJumpSounds sounds;
    public GameObject sandParticles;

    bool vai;
    public bool useMobile;
    // Use this for initialization
    void Start()
    {
        getCoins.text = coinManager.GetCoins().ToString();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        animator = GetComponent<Animator>();
        if (isTutorial == false)
        {
            sandParticles.SetActive(false);
            sounds = GameObject.Find("Sounds").GetComponent<LongJumpSounds>();
            personalScore = new float[] { -1f, -1f, -1f };
            jumpNumber = 0;
            pointsText.text = "0";
            jumpMessage.SetActive(false);
            resultCanvas.SetActive(false);
            betweenJumpsWindow.SetActive(false);
            jumpFailedMessage.SetActive(false);
            scoreBoard = new float[] { 0f, Random.Range(3.4f, 5.2f), Random.Range(4.0f, 5.3f), Random.Range(4.2f, 5f), Random.Range(4.5f, 5.5f) };
            adversaryNames = new string[] { "Manuela Larreta", "Yanis Kyrgiakos", "Ellen Banes", "Mi Yang Fu", "Olga Gouvêia", "Chidinma Essien", "Anouka Aymee", "Marie-Soleil Beau", "Rien Husen", "Liang Jin" };
            ShuffleNames();
            scoreBoardNames = new string[5];
            defaultText = "Parabéns, seu salto foi válido!\n Voce ganhou 50 moedas!\n\n";
        }
        Time.timeScale = 1;

#if MOBILE_INPUT
        useMobile = true;
#else
		 useMobile = false;
#endif
    }
    void Update()
    {
        if (canRun == true)
        {
            Run();
        }
        if (jump_reference.position.x >= transform.position.x && transform.position.x >= invalid_jump.position.x && jumpFailed == true)
        {
            if (isTutorial == false)
            {
                jumpMessage.SetActive(true);
            }
            canJump = true;
        }
        if (canJump == true)
        {
            Jump();
        }
        if (isJumping == true && isTutorial == false)
        {
            CalculateJumpDistance();
        }
        if (transform.position.x < invalid_jump.position.x && jumpFailed == true && isTutorial == false)
        {
            JumpFailed();
        }
        if (betweenJumps == true && isTutorial == false)
        {
            BetweenJumps();
        }
        if (-rb.velocity.x > 0 && canJump == false && isJumping == false)
        {
            rb.velocity -= (acceleration / 12) * -transform.forward;
        }
        else if (-rb.velocity.x < 0)
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Run()
    {
        if(useMobile == false) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && pressLeft == true)
            {
                leftFoot.SetActive(false);
                rightFoot.SetActive(true);
                pressLeft = false;
                if (-rb.velocity.x <= maxSpeed)
                {
                    rb.velocity += acceleration * -transform.forward;
                }
            }
#if MOBILE_INPUT
            if (CrossPlatformInputManager.GetButtonDown("LeftArrow") && pressLeft == true)
            {
                leftFoot.SetActive(false);
                rightFoot.SetActive(true);
                pressLeft = false;
                if (-rb.velocity.x <= maxSpeed)
                {
                    rb.velocity += acceleration * -transform.forward;
                }
                //Debug.Log("LeftArrow");
            }
#endif
            else if (Input.GetKeyDown(KeyCode.RightArrow) && pressLeft == false)
            {
                rightFoot.SetActive(false);
                leftFoot.SetActive(true);
                pressLeft = true;
                if (-rb.velocity.x <= maxSpeed)
                {
                    rb.velocity += acceleration * -transform.forward;
                }
            }
#if MOBILE_INPUT
            else if (CrossPlatformInputManager.GetButtonDown("RightArrow") && pressLeft == false)
            {
                rightFoot.SetActive(false);
                leftFoot.SetActive(true);
                pressLeft = true;
                if (-rb.velocity.x <= maxSpeed)
                {
                    rb.velocity += acceleration * -transform.forward;
                }
                Debug.Log("RightArrow");
            }
#endif
            else if (-rb.velocity.x > 0 && ((Input.GetKeyDown(KeyCode.LeftArrow) && pressLeft == false) || (Input.GetKeyDown(KeyCode.RightArrow) && pressLeft == true)))
            {
                rb.velocity -= (acceleration / 3) * -transform.forward;
            }
            //else if (-rb.velocity.x > 0 && ((CrossPlatformInputManager.GetButton("LeftArrow") && pressLeft == false) || (CrossPlatformInputManager.GetButton("RightArrow") && pressLeft == true)))
            //{
            //    rb.velocity -= (acceleration / 3) * -transform.forward;
            //}
            animator.SetFloat("speed", -rb.velocity.x);
        }
        if (useMobile == true)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0); // Obtém o primeiro toque registrado

                // Verifica se o toque está na metade esquerda ou direita da tela
                if (touch.position.x < Screen.width / 2 && pressLeft == true)
                {
                    // Atualiza a animação dos pés e o estado de movimento
                    leftFoot.SetActive(false);
                    rightFoot.SetActive(true);
                    pressLeft = false;

                    // Move o personagem para a esquerda
                    if (-rb.velocity.x <= maxSpeed)
                    {
                        rb.velocity += acceleration * -transform.forward;
                    }
                }
                else if (touch.position.x >= Screen.width / 2 && pressLeft == false)
                {
                    // Atualiza a animação dos pés e o estado de movimento
                    rightFoot.SetActive(false);
                    leftFoot.SetActive(true);
                    pressLeft = true;

                    // Move o personagem para a direita
                    if (-rb.velocity.x <= maxSpeed)
                    {
                        rb.velocity += acceleration * -transform.forward;
                    }
                }
            }
            // Modificado com Touch
            else if (-rb.velocity.x > 0)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    // Verifica se o toque está na metade esquerda ou direita da tela
                    if (touch.position.x < Screen.width / 2 && pressLeft == false)
                    {
                        // Desacelera o personagem ao trocar de direção durante o movimento
                        rb.velocity -= (acceleration / 3) * -transform.forward;
                    }
                    else if (touch.position.x >= Screen.width / 2 && pressLeft == true)
                    {
                        // Desacelera o personagem ao trocar de direção durante o movimento
                        rb.velocity -= (acceleration / 3) * -transform.forward;
                    }
                }
            }


            // Atualiza a animação de velocidade do personagem
            animator.SetFloat("speed", -rb.velocity.x);

        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
            jumpMessage.SetActive(false);
            rightFoot.SetActive(false);
            leftFoot.SetActive(false);
            if (SceneManager.GetActiveScene().name.Contains("utorial"))
            {
                rb.AddForce(Vector3.up * 70f);
            }
            else
            {
                rb.AddForce(Vector3.up * 250f);
            }
            animator.SetBool("jump", true);
            isJumping = true;
            canRun = false;
            canJump = false;
            jumpFailed = false;
            timer = Time.time;
        }
#if MOBILE_INPUT
        if (CrossPlatformInputManager.GetButtonDown("Space"))
        {
            vibrationController.VibrateDevice();
            rb.useGravity = true;
            jumpMessage.SetActive(false);
            rightFoot.SetActive(false);
            leftFoot.SetActive(false);
            if (SceneManager.GetActiveScene().name.Contains("utorial"))
            {
                rb.AddForce(Vector3.up * 70f);
            }
            else
            {
                rb.AddForce(Vector3.up * 250f);
            }
            animator.SetBool("jump", true);
            isJumping = true;
            canRun = false;
            canJump = false;
            jumpFailed = false;
            timer = Time.time;
        }
#endif
    }

    private void CalculateJumpDistance()
    {
        if (transform.position.y < 3.9)
        {
            if (transform.position.x > -44.8)
                JumpFailed();
            else
            {
                rb.useGravity = false;
                jumpDistance = (((transform.position.x + 45f) / -19f) * 1.4f) + 3.5f;
                personalScore[(jumpNumber - 1)] = jumpDistance;
                sandParticles.SetActive(true);
                rb.velocity -= 4f * -transform.forward;
                isJumping = false;
                betweenJumps = true;
            }
        }
    }

    private void JumpFailed()
    {
        jumpMessage.SetActive(false);
        canRun = false;
        canJump = false;
        jumpFailed = true;
        if (-rb.velocity.x < 15)
        {
            betweenJumps = true;
        }
        personalScore[jumpNumber - 1] = 0f;
        animator.SetFloat("speed", -rb.velocity.x);
    }

    private void BetweenJumps()
    {
        if (Time.time > timer + 2.5f)
        {
            if (jumpFailed == false)
            {
                betweenJumpsWindow.SetActive(true);
                sounds.PlayAudio(sounds.applause);
                string scoreText = "";
                for (int i = 0; i < 3; i++)
                {
                    Debug.Log("TESTE");
                    Debug.Log(i + ": " + personalScore[i]);
                    if (personalScore[i] >= 0)
                    {
                        if (personalScore[i] != 0)
                        {
                            scoreText = scoreText + (i + 1) + "º Salto: " + personalScore[i].ToString("0.00") + "m\n";
                        }
                        else
                        {
                            scoreText = scoreText + (i + 1) + "º Salto: X\n";
                        }
                    }
                }
                betweenJumpsText.text = defaultText + scoreText;
                betweenJumps = false;
                
            }
            else
            {
                jumpFailedMessage.SetActive(true);
                betweenJumps = false;
            }
        }
    }

    private void AddPoints(int n)
    {
        points += n;
        pointsText.text = "" + points;
        
    }
    
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void BackToMenu()
    {
        Application.LoadLevel("PlayAthletics");
    }

    public void ContinueButton()
    {
        betweenJumps = false;
        if (jumpFailed == false)
        {
            //AddPoints(200);
        }
        betweenJumpsWindow.SetActive(false);
        jumpFailedMessage.SetActive(false);
        if (jumpNumber < 3)
        {
            NewJump();
        }
        else
        {
            resultCanvas.SetActive(true);
            ScoreBoard();
        }
    }

    private void ScoreBoard()
    {
        scoreBoardNames[0] = "Verônica Hipólito";
        for (int i = 1; i < 5; i++)
        {
            scoreBoardNames[i] = adversaryNames[i];
        }
        float maxScore = 0f;
        for (int i = 0; i < 3; i++)
        {
            if (personalScore[i] > maxScore) maxScore = personalScore[i];
        }
        scoreBoard[0] = maxScore;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 4; j > i; j--)
            {
                if (scoreBoard[j] > scoreBoard[j - 1])
                {
                    float aux = scoreBoard[j];
                    scoreBoard[j] = scoreBoard[j - 1];
                    scoreBoard[j - 1] = aux;
                    string aux2 = scoreBoardNames[j];
                    scoreBoardNames[j] = scoreBoardNames[j - 1];
                    scoreBoardNames[j - 1] = aux2;
                }
            }
        }
        string message = " ", score = " ";
        if (scoreBoardNames[0] == "Verônica Hipólito")
        {
            message = "Parabéns, você ganhou medalha de ouro!\nVoce ganhou 100 moedas!\n\n";
            //AddPoints(1500);
            coinManager.AddCoins(100);

        }
        else if (scoreBoardNames[1] == "Verônica Hipólito")
        {
            message = "Parabéns, você ganhou medalha de prata!\nVoce ganhou 50 moedas!\n\n";
            //AddPoints(1000);
            coinManager.AddCoins(50);
        }
        else if (scoreBoardNames[2] == "Verônica Hipólito")
        {
            message = "Parabéns, você ganhou medalha de bronze!\nVoce ganhou 25 moedas!\n\n";
            //AddPoints(600);
            coinManager.AddCoins(25);
        }
        else
        {
            message = "Não foi dessa vez! Tente mais vezes e conquiste medalhas!\n\n";
        }
        for (int i = 0; i < 5; i++)
        {
            score = score + (i + 1) + "º lugar: " + scoreBoardNames[i] + " - " + scoreBoard[i].ToString("0.00") + "m\n";
        }
        resultText.text = message + score;

    }

    private void ShuffleNames()
    {
        for (int i = 9; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            string tmp = adversaryNames[i];
            adversaryNames[i] = adversaryNames[r];
            adversaryNames[r] = tmp;
        }
    }

    public void NewJump()
    {
        rb.useGravity = false;
        sandParticles.SetActive(false);
        jumpNumber++;
        rb.velocity = new Vector3(0f, 0f, 0f);
        pressLeft = true;
        rightFoot.SetActive(false);
        leftFoot.SetActive(true);
        betweenJumps = false;
        canRun = true;
        canJump = false;
        isJumping = false;
        jumpFailed = true;
        animator.SetBool("jump", false);
        animator.SetFloat("speed", 0.0f);
        transform.position = new Vector3(60.95f, 3.9f, 152.71f);
    }

}