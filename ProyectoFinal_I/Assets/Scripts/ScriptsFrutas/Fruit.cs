using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public string fruitName = "";
    
    private bool inicio = false;

    //La fruta cae una vez que se toca por 1a vez
    void OnTriggerEnter(Collider other) {        //Posible cambio a OnTriggerExit
        if (!inicio) {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            inicio = true;
        }
    }
}
