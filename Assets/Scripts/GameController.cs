using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using TMPro;

public class GameController : MonoBehaviour
{
    public Image Base;
    public Image vida;
    private float timer;
    private bool GameOver;
    public GameObject Jugador;
    public TextMeshProUGUI cronometro;
    public TextMeshProUGUI puntaje;
    private int puntos;
    private float vidaMax;
    private float vidaActual;
    public int intensificador;
   
    
  
    // Start is called before the first frame update
    void Start()
    {
        puntos = 0;
        vidaMax = 100;
        vidaActual = vidaMax; 
    }

    // Update is called once per frame
    void Update()
    {
        Cronometrar();
        PerderVida();
        Perder();
    }

    public void Cronometrar()
    {
        timer += Time.deltaTime;
        cronometro.text = "" + ((int)timer).ToString();
    }

    public void PerderVida()
    {
        vidaActual -= Time.deltaTime * intensificador;
        vida.fillAmount = vidaActual / vidaMax;
        if (vida.fillAmount > 0.66)
            Base.color = Convertor(new Vector3(255,255,4));
        if (vida.fillAmount < 0.66)
            Base.color = Convertor(new Vector3(255, 140, 4));
        if (vida.fillAmount < 0.33)
            Base.color = Convertor(new Vector3(255, 60, 4));
    }

    public Color Convertor(Vector3 color)
    {
        color /= 255;
        Color colorF = new Color(color.x, color.y, color.z);
        return colorF;
    }



    public void Curar()
    {
        vidaActual += 25f;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);

    }

    public bool Perder()
    {
        if (vida.fillAmount == 0)
            GameOver = true;
        return GameOver;
    }

    public void SumarP()
    {
        
        puntos++;
        puntaje.text = "" + puntos.ToString("0");
    }
}
