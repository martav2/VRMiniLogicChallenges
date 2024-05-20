using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerMode : MonoBehaviour {

    public Button buttonInfinito;
    public Button buttonContrarreloj;

    public Button buttonBack;
    public GameObject menuPrincipal;
    public GameObject menuModo;

    void Start() {
        buttonInfinito.onClick.AddListener(ActivarFuncion_Infinito);
        buttonContrarreloj.onClick.AddListener(ActivarFuncion_Contrarreloj);

        buttonBack.onClick.AddListener(ActivarMenu_Principal);
    }

    void ActivarMenu_Principal() {
        menuPrincipal.SetActive(true);
        menuModo.SetActive(false);
    }

    void ActivarFuncion_Infinito () {}
    void ActivarFuncion_Contrarreloj() {}


    
}
