using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {
    public TextMeshProUGUI display;
    public List<TextMeshProUGUI> displays;
    public List<MoleMov> moles = new List<MoleMov>();

    public int buttonSelectFunction = 0;
    public bool actualizar = false;
    
    private float timeChangeDisplay = 5f;
    private float lastTimeDisplay;
    private int correctDisplay;

    // Start is called before the first frame update
    void Start() {
        displays[0].text = "GO";
    }

    // Update is called once per frame
    // Cada timeChangeDisplay segundos actualiza los valores de todas las pantallas
    void Update() {
        if (Time.time - lastTimeDisplay >= timeChangeDisplay || actualizar == true) {
            actualizar = false;
            UpdateSelector();
            lastTimeDisplay = Time.time;
        }
    }

    void UpdateSelector () {
        if (buttonSelectFunction < 7 && buttonSelectFunction > 0){
            displays[0].text = "GO";
        }
        switch(buttonSelectFunction) {
            case 0:
                displays[0].text = "START";
                break;

            case 1:          
                UpdateAllDisplays_Num();
                break;
            case 2:
                UpdateAllDisplays_Sum();
                break;
            case 3:
                UpdateAllDisplays_Mayusc();
                break;
            case 4:
                UpdateAllDisplays_Minusc();
                break;
            case 5:
                UpdateAllDisplays_MayuscMinusc();
                break;
            case 6:
                UpdateAllDisplays_MinuscMayusc();
                break;
            default:
                displays[0].text = "ERROR";
                break;
        }
    }

    // Selecciona la pantalla 0 como la pantalla correcta, a cada pantalla se le asigna un numero aleatorio
    // a una de ellas se le da el valor correcto
    void UpdateAllDisplays_Num () {
        correctDisplay = Random.Range(1, displays.Count);
        int correctValue = 0;

        for (int i = 0; i < displays.Count; i++) {
            int randomNumber = Random.Range(0, 1000);
            if (i == 0) {
                correctValue = randomNumber;
            }

            if (i == correctDisplay) {
                displays[i].text = correctValue.ToString("000");    //Asegura que se muestren tres dígitos
                moles[i].correctMole = true;
            } else {
                if (i == 0) {
                    displays[i].text = randomNumber.ToString("000");
                } else {
                    displays[i].text = randomNumber.ToString("000");
                    moles[i].correctMole = false;
                }
            }
        }
    }

    // DISPLAY: 'X' + 'Y' MOLE: X+Y 
    void UpdateAllDisplays_Sum () {
        correctDisplay = Random.Range(1, displays.Count);
        int correctValue = 0;

        for (int i = 0; i < displays.Count; i++) {
            if (i == 0) {
                int randomNumber1 = Random.Range(1, 10);
                int randomNumber2 = Random.Range(1, 10);
                correctValue = randomNumber1 + randomNumber2;
                displays[i].text = randomNumber1 + "+" + randomNumber2;

            } else {
                int randomNumber = Random.Range(0, 20);
                if (i == correctDisplay) {
                    displays[i].text = correctValue.ToString("00");
                    moles[i].correctMole = true;
                } else {
                    displays[i].text = randomNumber.ToString("00");
                    moles[i].correctMole = false;
                }
            }
        }
    }

    // DISPLAY: mayusc MOLE: mayusc
    void UpdateAllDisplays_Mayusc () {
        correctDisplay = Random.Range(1, displays.Count);
        char correctValue = 'A';

        for (int i = 0; i < displays.Count; i++) {
            char randomChar = (char)Random.Range(65, 91);
            if (i == 0) {
                correctValue = randomChar;
                displays[i].text = randomChar.ToString();
            } else if (i == correctDisplay) {
                displays[i].text = correctValue.ToString();
                moles[i].correctMole = true;
            } else {
                displays[i].text = randomChar.ToString();
                moles[i].correctMole = false;
            }
        }
    }

    // DISPLAY: minusc MOLE: minusc
    void UpdateAllDisplays_Minusc () {
        correctDisplay = Random.Range(1, displays.Count);
        char correctValue = 'a';

        for (int i = 0; i < displays.Count; i++) {
            char randomChar = (char)Random.Range(97, 123);
            if (i == 0) {
                correctValue = randomChar;
                displays[i].text = randomChar.ToString();
            } else if (i == correctDisplay) {
                displays[i].text = correctValue.ToString();
                moles[i].correctMole = true;
            } else {
                displays[i].text = randomChar.ToString();
                moles[i].correctMole = false;
            }
        }
    }

    // DISPLAY: mayusc MOLE: minusc
    void UpdateAllDisplays_MayuscMinusc () {
        correctDisplay = Random.Range(1, displays.Count);
        char correctValue = 'a';

        for (int i = 0; i < displays.Count; i++) {
            char randomChar = (char)Random.Range(97, 123);
            if (i == 0) {
                correctValue = randomChar;
                char mayuscChar = char.ToUpper(randomChar);;
                displays[i].text = mayuscChar.ToString();

            } else if (i == correctDisplay) {
                displays[i].text = correctValue.ToString();
                moles[i].correctMole = true;
            } else {
                displays[i].text = randomChar.ToString();
                moles[i].correctMole = false;
            }
        }
    }

    // DISPLAY: minusc MOLE: mayusc
    void UpdateAllDisplays_MinuscMayusc () {
        correctDisplay = Random.Range(1, displays.Count);
        char correctValue = 'A';

        for (int i = 0; i < displays.Count; i++) {
            char randomChar = (char)Random.Range(65, 91);
            if (i == 0) {
                correctValue = randomChar;
                char mayuscChar = char.ToLower(randomChar);;
                displays[i].text = mayuscChar.ToString();

            } else if (i == correctDisplay) {
                displays[i].text = correctValue.ToString();
                moles[i].correctMole = true;
            } else {
                displays[i].text = randomChar.ToString();
                moles[i].correctMole = false;
            }
        }
    }
}
