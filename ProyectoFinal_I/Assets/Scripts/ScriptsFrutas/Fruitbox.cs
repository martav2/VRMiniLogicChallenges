using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitbox : MonoBehaviour {

    public DisplayPointsFruits displayPointsFruits;
    public ParticleSystem particles;
    public SpawnFruits spawnFruits;

    public AudioSource audioCorrectFruit;
    public AudioSource audioWrongFruit;

    //Compara si la fruta va a la caja correcta
    void OnTriggerEnter(Collider other) {
        string boxTag = gameObject.tag;

        if (other.gameObject.layer == 12) {     //Capa 12 => Capa fruta

            if (other.CompareTag(boxTag)) {
                displayPointsFruits.SumarPuntos();

                if(particles != null) {
                    CambiarColorParticulas(Color.white);
                    particles.Play();
                    audioCorrectFruit.Play();

                }
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

    //Cambia el color de las particulas al que se le indica
    void CambiarColorParticulas(Color color) {
        Material particleMaterial = particles.GetComponent<Renderer>().material;
        particleMaterial.color = color;
    }

}

    



