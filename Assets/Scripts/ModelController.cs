using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GEM"))
        {
            LevelController.Instance.addGem();
            gameController.SumarP();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("HEALTH"))
        {
            controller.addHealth();
            gameController.Curar();
            Destroy(other.gameObject);
        }
        
      
    }
}