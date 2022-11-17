using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>() ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GEM"))
        {
            LevelController.Instance.addGem();
            gameController.SumarP();
            Destroy(other.gameObject);
            audioManager.SeleccionarAudio(1, 0.5f);// sonido de puntos
        }

        if (other.CompareTag("HEALTH"))
        {
            controller.addHealth();
            gameController.Curar();
            Destroy(other.gameObject);
            audioManager.SeleccionarAudio(2, 0.5f); // sonido de curarse
        }
        
      
    }
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.CompareTag("CAR"))
        {
            audioManager.SeleccionarAudio(3, 0.5f);
        }
    }

}