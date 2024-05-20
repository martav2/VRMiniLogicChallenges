using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour {

    public GameObject[] frutas;
    public GameObject spawnedFruits;
    public int numdeFrutas = 0;
    public int maxdeFrutas = 25;

    public bool fruitsRain = false;
    public bool exit = false;

    float temporizador = 0;
    public float spawnTime = 3;
    string nameWalls = "Collider";

    public event System.Action FruitsDeleted = delegate { };

    void Start() {
        if (fruitsRain) {
            float x, y, z;

            for (int i = 0; i < 10; i++) {

                if (RoomPassThrough.RoomIsLoad()) {
                    Vector3[] roomSize = RoomPassThrough.GetMinMaxPoints();
                    do {
                        x = Random.Range(roomSize[0].x, roomSize[1].x);
                        y = Random.Range(roomSize[0].y+0.2f, roomSize[1].y - 0.3f);
                        z = Random.Range(roomSize[0].z, roomSize[1].z);

                    } while (!RoomPassThrough.PointInsideWallsRoom(new Vector3(x, y, z), nameWalls));

                    //Seleccion de Fruta a instanciar
                    int frutaAleatoria = Random.Range(0, frutas.Length);
                    GameObject spawnFruit = frutas[frutaAleatoria];;
                    
                    //Intancia de la fruta
                    GameObject fruitInstance = Instantiate(spawnFruit, new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)));

                    //Cambio del padre de la fruta a spawnedFruits
                    fruitInstance.transform.SetParent(spawnedFruits.transform);

                    numdeFrutas++;
                }
            }
        }
    }

    // Update is called once per frame
    void LateUpdate() {

        if (!exit) {

            float x, y, z;

            if (temporizador >= spawnTime && numdeFrutas < maxdeFrutas) {
                if (RoomPassThrough.RoomIsLoad()) {
                    Vector3[] roomSize = RoomPassThrough.GetMinMaxPoints();
                    do {
                        x = Random.Range(roomSize[0].x, roomSize[1].x);
                        y = Random.Range(roomSize[0].y+0.2f, roomSize[1].y - 0.3f);
                        z = Random.Range(roomSize[0].z, roomSize[1].z);

                    } while (!RoomPassThrough.PointInsideWallsRoom(new Vector3(x, y, z), nameWalls));

                    //Seleccion de Fruta a instanciar
                    int frutaAleatoria = Random.Range(0, frutas.Length);
                    GameObject spawnFruit = frutas[frutaAleatoria];;
                    
                    //Intancia de la fruta
                    GameObject fruitInstance = Instantiate(spawnFruit, new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)));

                    //Cambio del padre de la fruta a spawnedFruits
                    fruitInstance.transform.SetParent(spawnedFruits.transform);

                    numdeFrutas++;
                    temporizador = 0;
                }
            }
            temporizador += Time.deltaTime;
        }
    }

    //Eliminar todas las spawnedFruits
    public void DeleteSpawnedFruits() {
        exit = true;
        StartCoroutine(DeleteSpawnedFruitsCoroutine());
    }

    //Eliminar todas las spawnedFruits en orden
    IEnumerator DeleteSpawnedFruitsCoroutine() {
        while (spawnedFruits.transform.childCount > 0) {
            Transform oldestChild = spawnedFruits.transform.GetChild(0);
            Destroy(oldestChild.gameObject);
            numdeFrutas--;
            yield return null;
        }
    
        //Avisa de que todas las frutas se han eliminado
        FruitsDeleted();
    }
}

