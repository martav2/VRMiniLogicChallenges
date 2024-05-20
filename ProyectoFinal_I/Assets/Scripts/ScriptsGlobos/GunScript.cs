using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public GameObject shotPoint1;
    public GameObject shotPoint2;
    public DisplayPointsFruits displayPointsFruits;
    public FindTheBalloon findTheBalloon;
    public SpawnBalloons spawnBalloons;

    // Update is called once per frame
    void Update() {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) { // Secondary derecha primary izquierda
            Vector3 dir = (shotPoint2.transform.position - shotPoint1.transform.position).normalized;
            RaycastHit[] hitInfo;
            hitInfo = Physics.RaycastAll(shotPoint1.transform.position, dir, 100.0f);
            //Debug.DrawRay(shotPoint1.transform.position, dir,UnityEngine.Color.red, 100.0f);
            foreach (RaycastHit hit in hitInfo) {
                if (hit.collider.gameObject.tag == "Balloon") {

                    if (CompareBalloonColor(hit.collider.gameObject) ) {
                        displayPointsFruits.SumarPuntos();
                        findTheBalloon.actualizar = true;
                    } else {
                        displayPointsFruits.RestarPuntos();
                    }

                    Destroy(hit.collider.gameObject);
                    spawnBalloons.numdeGlobos--;
                }
            }
        }
    }

   /* public bool CompareBalloonColor(GameObject balloon) {

        Material balloonMaterial = balloon.GetComponent<Material>();
        
        if (balloonMaterial != null) {
            return balloonMaterial == findTheBalloon.newColor;
        }
        return false;
    }*/

    /*public bool CompareBalloonColor(GameObject balloon) {
        Renderer balloonRenderer = balloon.GetComponent<Renderer>();
        
        if (balloonRenderer != null) {
            Material balloonMaterial = balloonRenderer.material;
            return balloonMaterial.name == findTheBalloon.newColor.name + " (Instance)"; // Comparar nombres
        }
        return false;
    }*/

    public bool CompareBalloonColor(GameObject balloon) {
        Renderer balloonRenderer = balloon.GetComponent<Renderer>();
        
        if (balloonRenderer != null) {
            Color balloonColor = balloonRenderer.material.color;
            Color targetColor = findTheBalloon.newColor.color;
            return balloonColor.Equals(targetColor);
        }
        return false;
    }
}
