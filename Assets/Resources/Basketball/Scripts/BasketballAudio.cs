using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballAudio : MonoBehaviour
{
    public AudioClip audioInicial; // Áudio no início da gameplay
    public AudioClip sfxPontuacao; // SFX para quando há pontuação
    public AudioClip audioDeFundo; // Áudio de fundo após o áudio inicial
    private AudioSource audioSource;
    private static BasketballAudio basketballAudio;

    private void Awake()
    {
        basketballAudio = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Toca o áudio inicial no início da gameplay
        if (audioInicial != null)
        {
            audioSource.clip = audioInicial;
            audioSource.Play();
        }
    }

    // Função para tocar o SFX de pontuação
    public void TocarSFXPontuacao()
    {
        if (sfxPontuacao != null)
        {
            audioSource.PlayOneShot(sfxPontuacao);
        }
    }

    void Update()
    {
        // Verifica se o áudio inicial terminou de tocar e inicia o áudio de fundo
        if (!audioSource.isPlaying && audioDeFundo != null)
        {
            audioSource.clip = audioDeFundo;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
