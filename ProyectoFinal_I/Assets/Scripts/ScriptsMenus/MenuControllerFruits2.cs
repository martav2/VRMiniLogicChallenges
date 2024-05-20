using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerFruits2 : MonoBehaviour {
    public Button buttonBack;
    public GameObject menuPrincipal;
    public GameObject menuActual;
    public GameObject juegoActual;
    public SpawnFruits spawnFruits;

    void Start() {
        buttonBack.onClick.AddListener(ActivarMenu_Principal);
        spawnFruits.FruitsDeleted += FruitsDeleted; //Suscripción al evento de eliminación de frutas
    }

    void ActivarMenu_Principal() {
        spawnFruits.DeleteSpawnedFruits();
    }

    void FruitsDeleted() {
        spawnFruits.exit = false;
        juegoActual.SetActive(false);
        menuActual.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    void OnDestroy() {      //Desuscribirse del evento cuando el objeto se destruye
        if (spawnFruits != null) {
            spawnFruits.FruitsDeleted -= FruitsDeleted;
        }
    }
}
