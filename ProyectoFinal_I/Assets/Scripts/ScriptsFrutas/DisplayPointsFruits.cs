using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPointsFruits : MonoBehaviour {
    
    public static DisplayPointsFruits Instance;
    
    public TextMeshProUGUI pointsDisplay;

    public int puntosCorrectos = 3;
    public int puntosIncorrectos = 1;
    public int points = 0;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        }/*else{
            Destroy(gameObject);
        }*/
    }

    void OnEnable() {
        points = 0;
    }

    void Update() {
        pointsDisplay.text = points.ToString(); //"" + Instance.points;
    }

    public void SumarPuntos() {
        points += puntosCorrectos;
    }

    public void RestarPuntos() {
        //if (points >= puntosIncorrectos) {
            points -= puntosIncorrectos;
        /*} else {
            points = 0;
        }*/
    }

    private void OnDisable() {
        points = 0;
        //Instance = null;
        if (Instance == this) {
            Instance = null;
        }
    }
}
