using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerMenu : MonoBehaviour {

    public Button buttonTopos;
    public Button buttonFrutas;
    public Button buttonGlobos;

    public GameObject menuTopos;
    public GameObject menuFrutas;
    public GameObject menuGlobos;
    public GameObject menuPrincipal;

    public GameObject juegoTopos;
    public GameObject juegoFrutas; 
    public GameObject juegoGlobos;
    
    void Start() {
        buttonTopos.onClick.AddListener(ActivarMenu_Topos);
        buttonFrutas.onClick.AddListener(ActivarMenu_Frutas);
        buttonGlobos.onClick.AddListener(ActivarMenu_Globos);
    }

    void ActivarMenu_Topos() {
        menuPrincipal.SetActive(false);
        menuTopos.SetActive(true);
        juegoTopos.SetActive(true);
    }

    void ActivarMenu_Frutas() {
        menuPrincipal.SetActive(false);
        menuFrutas.SetActive(true);
        juegoFrutas.SetActive(true);
    }

    void ActivarMenu_Globos() {
        menuPrincipal.SetActive(false);
        menuGlobos.SetActive(true);
        juegoGlobos.SetActive(true);
    }
}

