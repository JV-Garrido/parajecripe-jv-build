using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PositionPlayerInGame : MonoBehaviour
{
    [Header("Player e Oponents")]
    public Transform player, opponent, opponent2;
    public int currentposition;
    int finalPosition;
    public Text positionText;
    public Text currentpositionText;
    public Text titulo;
    public SystemMainSwimmingV4 swimmingV4;
    public string sceneName;
    [Header("CoinManager")]
    public CoinManager coinManager;
    public int primeiro;
    public int segundo;
    public int terceiro;
    public Text grantText;
    public Text getText;
    string vitoria = "Você Ganhou!";
    string derrota = "Você Perdeu!";
    bool finaldojogo;

    public Text place1Text;
    public Text place2Text;
    public Text place3Text;

    private string place1Name;
    private string place2Name;
    private string place3Name;

    bool podePremiar;

    void Start()
    {
        place1Name = "Clodoaldo Silva";
        place2Name = "Opponent 01";
        place3Name = "Opponent 02";
    }

    void Update()
    {
        getText.text = "Você tem "+coinManager.GetCoins().ToString() + " moedas";
        if (player.position.z > opponent.position.z && player.position.z > opponent2.position.z)
        {
            currentposition = 1;
            currentpositionText.text = currentposition.ToString();     
        }
        else if (player.position.z < opponent.position.z && player.position.z > opponent2.position.z && opponent2.position.z < opponent.position.z || player.position.z > opponent.position.z && player.position.z < opponent2.position.z && opponent2.position.z > opponent.position.z)
        {
            currentposition = 2;
            currentpositionText.text = currentposition.ToString();
        }
        else if (player.position.z < opponent.position.z && player.position.z < opponent2.position.z)
        {
            currentposition = 3;
            currentpositionText.text = currentposition.ToString();
        }

        if (currentposition != finalPosition)
        {
            finalPosition = currentposition;
            UpdatePlaceNames();
        }

        positionText.text = finalPosition.ToString();
        Debug.Log(finalPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && finalPosition > 1)
        {
            titulo.text = derrota;
            //DERROTA
            swimmingV4.GameOver();
            Debug.Log("Derrota");
            Debug.Log("Player foi");
        }
        else if (other.gameObject.CompareTag("Player") && finalPosition <= 1)
        {
            titulo.text = vitoria;
            //vitoria
            swimmingV4.Victory();
            Debug.Log("Vitoria");
        }
        else if (other.gameObject.CompareTag("Opponent"))
        {
            finalPosition++;
            Debug.Log("Opponent foi");
        }
        GrantCoins();
        UpdatePlaceNames();
    }

    public void SairDoJogo()
    {
        SceneManager.LoadScene(sceneName);
    }

    void UpdatePlaceNames()
    {
        if (finalPosition == 1)
        {
            place1Text.text = place1Name;
            place2Text.text = place2Name;
            place3Text.text = place3Name;           
        }
        else if (finalPosition == 2)
        {
            place1Text.text = place2Name;
            place2Text.text = place1Name;
            place3Text.text = place3Name; 
        }
        else if (finalPosition == 3)
        {
            place1Text.text = place3Name;
            place2Text.text = place2Name;
            place3Text.text = place1Name;    
        }
    }

    void GrantCoins()
    {
        if (finalPosition == 1)
        {
            coinManager.AddCoins(primeiro);
            grantText.text = "Você ganhou um total de" + primeiro.ToString() + " moedas";
        }
        else if (finalPosition == 2)
        {
            coinManager.AddCoins(segundo);
            grantText.text = "Você ganhou um total de " + segundo.ToString() + " moedas";
        }
        else if (finalPosition == 3)
        {
            coinManager.AddCoins(terceiro);
            grantText.text = "Você ganhou um total de " + terceiro.ToString() + " moedas";
        }
    }
}
