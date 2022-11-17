using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject MenuP;
    [SerializeField] private GameObject MenuGO;
    [SerializeField] private GameObject MenuControles;
    [SerializeField] private Player playerInput;
    private bool pausa;
    bool empezar = false;
    private bool GM;
    [SerializeField] private GameObject gameController;
    [SerializeField] private TextMeshProUGUI puntosf;
    private AudioManager audioManager;//
    [SerializeField] private GameObject jugador;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();// Busca el objeto instanciado en el proyecto
    }
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
        audioManager.SeleccionarAudio(0, 0.5f);// reproduce sonido botones
        audioManager.EncenderMusica(jugador); // enciende la musica
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
        audioManager.SeleccionarAudio(0, 0.5f);
        pausa = false;
    }
    public void Salir()
    {
        audioManager.SeleccionarAudio(0, 0.5f);
        Application.Quit();// no se nota desde unity.
    }

    public void OnPausar(InputValue valor)
    {
        pausa = !pausa;
        audioManager.SeleccionarAudio(0, 0.5f);
    }

    public void Perder()
    {
        GM = gameController.GetComponent<GameController>().Perder();
        if (GM == true)
        {
            audioManager.SeleccionarAudio(4, 0.5f);// reproduce GM
            audioManager.ApagarMusica(jugador); //Se apaga la musica
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
        audioManager.SeleccionarAudio(0, 0.5f);
        MenuControles.SetActive(true);
    }

    public void SalirDeControles()
    {
        audioManager.SeleccionarAudio(0, 0.5f);
        MenuControles.SetActive(false);
    }
}
