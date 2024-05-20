using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloons : MonoBehaviour {
    
    public GameObject[] globos;
    public GameObject spawnedBalloons;
    public int numdeGlobos = 0;
    public int maxdeGlobos = 25;

    public Material[] materials;

    //public GameObject spawnObject;
    float temporizador = 0;
    public float spawnTime = 3;
    string nameWalls = "Collider";

    public event System.Action BalloonsDeleted = delegate { };
    public bool exit = false;

    //Vector3[] roomSize;

    // Update is called once per frame
    void LateUpdate() {

        if (!exit) {

            float x, y, z;

            if (temporizador >= spawnTime && numdeGlobos < maxdeGlobos) {
                if (RoomPassThrough.RoomIsLoad()) {
                    Vector3[] roomSize = RoomPassThrough.GetMinMaxPoints();
                    do {
                        x = Random.Range(roomSize[0].x+0.3f, roomSize[1].x-0.3f);
                        y = Random.Range(roomSize[0].y+0.2f, roomSize[1].y - 0.3f);
                        z = Random.Range(roomSize[0].z+0.3f, roomSize[1].z-0.3f);

                    } while (!RoomPassThrough.PointInsideWallsRoom(new Vector3(x, y, z), nameWalls));

                    //Seleccion del Globo a instanciar
                    int globoAleatorio = Random.Range(0, globos.Length);
                    GameObject spawnBalloon = globos[globoAleatorio];;
                    
                    //Intancia de la fruta
                    GameObject balloonInstance = Instantiate(spawnBalloon, new Vector3(x, y, z), Quaternion.Euler(new Vector3(270, 0, 0)));
                    
                    //Cambio del padre de la fruta a spawnedFruits
                    balloonInstance.transform.SetParent(spawnedBalloons.transform);

                    // Asignar un material aleatorio
                    Renderer renderer = balloonInstance.GetComponent<Renderer>();
                    if (renderer != null && materials.Length > 0) {
                        int index = Random.Range(0, materials.Length);
                        renderer.material = materials[index];
                    }
                    
                    numdeGlobos++;
                    temporizador = 0;
                }
            }
            temporizador += Time.deltaTime;
        }
    }

    //Eliminar todas las spawnedBalloons
    public void DeleteSpawnedBalloons() {
        exit = true;
        StartCoroutine(DeleteSpawnedBalloonsCoroutine());
    }

    //Eliminar todas las spawnedBalloons en orden
    IEnumerator DeleteSpawnedBalloonsCoroutine() {
        while (spawnedBalloons.transform.childCount > 0) {
            Transform oldestChild = spawnedBalloons.transform.GetChild(0);
            Destroy(oldestChild.gameObject);
            numdeGlobos--;
            yield return null;
        }
    
        //Avisa de que todas las frutas se han eliminado
        BalloonsDeleted();
    }

}
