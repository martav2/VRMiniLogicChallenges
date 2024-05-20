using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodFruitbox : MonoBehaviour {

    public ParticleSystem particles;

    public DisplayPointsFruits displayPointsFruits;
    public FindTheFruit findTheFruit;
    public SpawnFruits spawnFruits;
    
    public AudioSource audioCorrectFruit;
    public AudioSource audioWrongFruit;

    //Compara si la fruta va a la caja correcta
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.layer == 12) {     //Capa 12 => Capa fruta

            if (CompareFruitWithImage(other.gameObject) ) {
                displayPointsFruits.SumarPuntos();

                if(particles != null) {
                    CambiarColorParticulas(Color.white);
                    particles.Play();
                    audioCorrectFruit.Play();
                }
                findTheFruit.actualizar = true;
            } else {
                displayPointsFruits.RestarPuntos();
                if(particles != null) {
                    CambiarColorParticulas(Color.red);
                    particles.Play();
                    audioWrongFruit.Play();
                }
            }

            Destroy(other.gameObject);      //Una vez en contacto con una caja, la fruta se elimina
            spawnFruits.numdeFrutas--;
        }
    }

    public bool CompareFruitWithImage(GameObject fruit) {
        Fruit fruitScript = fruit.GetComponent<Fruit>();
        
        if (fruitScript != null) {
            string currentSpriteName = findTheFruit.newIconFruit.sprite.name;
            return fruitScript.fruitName == currentSpriteName;
        }
        return false;
    }

    //Cambia el color de las particulas al que se le indica
    void CambiarColorParticulas(Color color) {
        Material particleMaterial = particles.GetComponent<Renderer>().material;
        particleMaterial.color = color;
    }
}

