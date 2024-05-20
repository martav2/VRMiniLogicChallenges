using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerGlobos : MonoBehaviour {
    public Button buttonBack;
    public GameObject menuPrincipal;
    public GameObject menuActual;
    public GameObject juegoActual;
    public SpawnBalloons spawnBalloons;

    void Start() {
        buttonBack.onClick.AddListener(ActivarMenu_Principal);
        spawnBalloons.BalloonsDeleted += BalloonsDeleted; //Suscripción al evento de eliminación de globos
    }

    void ActivarMenu_Principal() {
        spawnBalloons.DeleteSpawnedBalloons();
    }

    void BalloonsDeleted () {
        spawnBalloons.exit = false;
        juegoActual.SetActive(false);
        menuActual.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    void OnDestroy () {     //Desuscribirse del evento cuando el objeto se destruye
        if (spawnBalloons != null) {
            spawnBalloons.BalloonsDeleted -= BalloonsDeleted;
        }
    }
}
