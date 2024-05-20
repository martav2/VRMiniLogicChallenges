using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using TMPro;

public class MoleMov : MonoBehaviour {

    private float speed = 1.5f;
    private float rangemov = 0.4f;
    private float startY;

    public float startTime;
    private float direction = -1f;     //Se puede alternar con 1f para mov contrario, da fallos en hit

    public bool isHit = false;         //Topo golpeado
    public bool correctMole = false;    //Topo correcto golpeado

    public DisplayPoints displayPoints;
    public DisplayText displayText;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start () {
        startTime = Time.time;
        startY = transform.position.y - rangemov;
    }

    // Update is called once per frame
    void Update () {
        
        if (!isHit) {
            float posY = Mathf.Sin((Time.time - startTime) * speed) * rangemov * direction;
            transform.position = new Vector3(transform.position.x, startY + posY, transform.position.z);
            
        } else {
            transform.position = new Vector3(transform.position.x, startY - rangemov, transform.position.z);

            isHit = false;
            startTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject != null && other.gameObject.CompareTag("Mazo")) {

            audioSource.Play();
            isHit = true;   //Topo Golpeado
            if(correctMole) {
                displayPoints.SumarPuntos();
                displayText.actualizar = true;
            } else {
                displayPoints.RestarPuntos();
            }
        }
    }
}

