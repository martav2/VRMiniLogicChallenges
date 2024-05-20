using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public DisplayText displayTextScript;

    public Button buttonNum;
    public Button buttonSum;
    public Button buttonMayusc;
    public Button buttonMinusc;
    public Button buttonMayuscMinusc;
    public Button buttonMinuscMayusc;

    public Button buttonBack;
    public GameObject menuTopos;
    public GameObject menuPrincipal;
    public GameObject juegoTopos;
    
    void Start() {
        buttonNum.onClick.AddListener(ActivarFuncion_Num);
        buttonSum.onClick.AddListener(ActivarFuncion_Sum);
        buttonMayusc.onClick.AddListener(ActivarFuncion_Mayusc);
        buttonMinusc.onClick.AddListener(ActivarFuncion_Minusc);
        buttonMayuscMinusc.onClick.AddListener(ActivarFuncion_MayuscMinusc);
        buttonMinuscMayusc.onClick.AddListener(ActivarFuncion_MinuscMayusc);

        buttonBack.onClick.AddListener(ActivarMenu_Principal);
    }

    void ActivarMenu_Principal() {
        menuPrincipal.SetActive(true);
        menuTopos.SetActive(false);
        juegoTopos.SetActive(false);
    }

    void ActivarFuncion_Num() {
        displayTextScript.buttonSelectFunction = 1;
    }

    void ActivarFuncion_Sum() {
        displayTextScript.buttonSelectFunction = 2;
    }

    void ActivarFuncion_Mayusc() {
        displayTextScript.buttonSelectFunction = 3;
    }

    void ActivarFuncion_Minusc() {
        displayTextScript.buttonSelectFunction = 4;
    }

    void ActivarFuncion_MayuscMinusc() {
        displayTextScript.buttonSelectFunction = 5;
    }

    void ActivarFuncion_MinuscMayusc() {
        displayTextScript.buttonSelectFunction = 6;
    }
}
