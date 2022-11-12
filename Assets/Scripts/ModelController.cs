using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GEM"))
        {
            LevelController.Instance.addGem();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("HEALTH"))
        {
            controller.addHealth();
            Destroy(other.gameObject);
        }
    }
}