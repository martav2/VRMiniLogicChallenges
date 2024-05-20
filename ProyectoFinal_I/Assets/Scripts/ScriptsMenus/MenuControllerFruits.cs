using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuControllerFruits : MonoBehaviour {

    public Button buttonBack;

    public Button buttonExplora;
    public Button buttonClasifica;
    public Button buttonEncuentra;
    public Button buttonSelecciona;

    public GameObject menuPrincipal;
    public GameObject menuActual;

    public GameObject JuegoActual;
    
    public GameObject[] juegoFrutasList;
    public GameObject[] menuFrutasList;

    void Start() {
        buttonBack.onClick.AddListener(ActivarMenu_Principal);

        buttonExplora.onClick.AddListener(ActivarMenu_Explorar);
        buttonClasifica.onClick.AddListener(ActivarMenu_Clasificar);
        buttonEncuentra.onClick.AddListener(ActivarMenu_Encontrar);
        buttonSelecciona.onClick.AddListener(ActivarMenu_Seleccionar);
    }

    void ActivarMenu_Principal() {
        menuPrincipal.SetActive(true);
        menuActual.SetActive(false);
        JuegoActual.SetActive(false);
    }

    //Juego libre, puedes experimentar como quieras con las frutas
    void ActivarMenu_Explorar() {
        menuActual.SetActive(false);
        menuFrutasList[0].SetActive(true);
        juegoFrutasList[0].SetActive(true);
    }

    //Tienes cajas de colores y debes colocar cada fruta en la caja de su color
    void ActivarMenu_Clasificar() {
        menuActual.SetActive(false);
        menuFrutasList[1].SetActive(true);
        juegoFrutasList[1].SetActive(true);
    }

    //Te aparece la imagen de una fruta, debes encontrarla y colocarla en la caja
    void ActivarMenu_Encontrar() {
        menuActual.SetActive(false);
        menuFrutasList[2].SetActive(true);
        juegoFrutasList[2].SetActive(true);
    }

    //Debes tocar una fruta segun 'X'
    void ActivarMenu_Seleccionar() {
        /*menuActual.SetActive(false);
        menuFrutas2.SetActive(true);*/
    }
}
