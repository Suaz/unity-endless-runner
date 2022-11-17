using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] ListaAudios;
    private AudioSource controlAudio;

    void Awake()
    {
        controlAudio = GetComponent<AudioSource>();// instanciar
    }

   
    public void SeleccionarAudio(int indice, float volumen)
    {
        controlAudio.PlayOneShot(ListaAudios[indice], volumen);// reproduce el sonido 1 vez
    }

    public void EncenderMusica(GameObject jugador)
    {
        jugador.SetActive(true);
    }

    public void ApagarMusica(GameObject jugador)
    {
        jugador.SetActive(false);
    }
}
