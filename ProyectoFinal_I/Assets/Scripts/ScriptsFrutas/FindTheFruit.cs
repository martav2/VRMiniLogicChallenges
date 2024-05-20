using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FindTheFruit : MonoBehaviour {

    public Image newIconFruit;
    public TextMeshProUGUI nombreFruta;
    public Sprite[] fruitsIcons;

    public bool actualizar = false;
    private int index = 0;
    
    private float timeChangeDisplay = 5f;
    private float lastTimeDisplay;

    // Update is called once per frame
    void Update() {
        if (Time.time - lastTimeDisplay >= timeChangeDisplay || actualizar == true) {
            actualizar = false;
            UpdateIconFruit();
            lastTimeDisplay = Time.time;
        }
    }

    void UpdateIconFruit () {

        newIconFruit.sprite = fruitsIcons[index];
        nombreFruta.text = newIconFruit.sprite.name;

        index++;
        if (index >= fruitsIcons.Length) {
            index = 0;
        }
    }
}
