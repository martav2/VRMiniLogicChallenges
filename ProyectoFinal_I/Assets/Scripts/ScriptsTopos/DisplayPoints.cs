using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPoints : MonoBehaviour {
    
    public static DisplayPoints Instance;

    public TextMeshProUGUI pointsDisplay;

    public int puntosCorrectos = 3;
    public int puntosIncorrectos = 1;
    private int points = 0;

    void Awake() {
        if(Instance == null) {
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }

    void Update() {
        pointsDisplay.text = "Puntos: " + Instance.points;
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
}


