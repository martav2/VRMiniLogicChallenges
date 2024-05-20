using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMov : MonoBehaviour {
    public float upDowwnSpeed;
    float yValue = 0;
    bool upDown = false;
    Vector3[] roomSize;
    
    // Start is called before the first frame update
    void Start() {
        if (RoomPassThrough.RoomIsLoad()) {
            roomSize = RoomPassThrough.GetMinMaxPoints();
        }
    }

    // Update is called once per frame
    void LateUpdate() {
        UpdownBalloons();
    }

    //------------------------------------------------------------------------------
    //funtion Name: UpdownBalloons
    //Balloons move up and down inside the room
    //------------------------------------------------------------------------------
    void UpdownBalloons() {
        yValue = 0;
        
        if (upDown) {
            yValue = yValue + Time.deltaTime * upDowwnSpeed;
        } else if (!upDown) {
            yValue = yValue - Time.deltaTime * upDowwnSpeed;
        }
        
        if (gameObject.transform.position.y >= roomSize[1].y - 0.3f) {
            upDown = false;
        } else if (gameObject.transform.position.y <= roomSize[0].y + 0.3f) {
            upDown = true;
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yValue, gameObject.transform.position.z);
    }
}
