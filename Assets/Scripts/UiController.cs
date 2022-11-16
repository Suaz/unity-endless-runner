using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject MenuP;
    [SerializeField] GameObject MenuGO;
    [SerializeField] GameObject MenuControles;
    [SerializeField] Player playerInput;
    private bool pausa;
    bool empezar = false;
    private bool GM;
    [SerializeField] GameObject gameController;
    [SerializeField] TextMeshProUGUI puntosf;

    

    void Start()
    {
        playerInput = new Player();
        GM = false;
        IniciarMenu();
        pausa = false;
        
      
    }


    void Update()
    {
        Pausar();
        Reanudar();
        Comenzar();
        Perder();

    }

    public void Comenzar()
    {
        if (empezar == false)
            Time.timeScale = 0f;
    }

    public void IniciarMenu()
    {
        Menu.SetActive(true);


    }

    public void Jugar()
    {
        Menu.SetActive(false);
        MenuGO.SetActive(false);
        Time.timeScale = 1f;
        empezar = true;
        playerInput.Enable();
        GM = false;
    }

    public void Pausar()
    {
        if (pausa == true)
        {
            Time.timeScale = 0f;
            MenuP.SetActive(true);
        }
    }

    public void Reanudar()
    {

        if (pausa == false)
        {
            Time.timeScale = 1f;
            MenuP.SetActive(false);
        }
    }

    public void Continuar()
    {
        pausa = false;
    }
    public void Salir()
    {
        Application.Quit();// no se nota desde unity.
    }

    public void OnPausar(InputValue valor)
    {
        pausa = !pausa;

    }

    public void Perder()
    {
        GM = gameController.GetComponent<GameController>().Perder();
        if (GM == true)
        {
            Time.timeScale = 0f;
            MenuGO.SetActive(true);
            playerInput.Disable();
            puntosf.text = gameController.GetComponent<GameController>().puntaje.text;
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void EntrarAControles()
    {
        MenuControles.SetActive(true);
    }

    public void SalirDeControles()
    {
        MenuControles.SetActive(false);
    }
}
