using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindTheBalloon : MonoBehaviour {

    public Material newColor;
    public TextMeshProUGUI nombreColor;
    public Material[] materials;

    public bool actualizar = false;
    private int index = 0;
    
    private float timeChangeDisplay = 5f;
    private float lastTimeDisplay;

    // Update is called once per frame
    void Update() {
        if (Time.time - lastTimeDisplay >= timeChangeDisplay || actualizar == true) {
            actualizar = false;
            UpdateColorBalloon();
            lastTimeDisplay = Time.time;
        }
    }

    void UpdateColorBalloon () {

        index = Random.Range(0, materials.Length);

        newColor = materials[index];
        nombreColor.text = newColor.name;
    }
}
