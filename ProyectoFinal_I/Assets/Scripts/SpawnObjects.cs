using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObjects : MonoBehaviour {

    public GameObject spawnObject;
    float temporizador = 0;
    public float spawnTime;
    string nameWalls = "Collider";
    //string nameGlobalMesh = "PTRLGlobalMesh(Clone)";
    Vector3[] roomSize;

    // Update is called once per frame
    void LateUpdate() {

        float x, y, z;

        if (temporizador >= spawnTime) {
            if (RoomPassThrough.RoomIsLoad()) {
                Vector3[] roomSize = RoomPassThrough.GetMinMaxPoints();
                do {
                    x = Random.Range(roomSize[0].x, roomSize[1].x);
                    y = Random.Range(roomSize[0].y+0.2f, roomSize[1].y - 0.3f);
                    z = Random.Range(roomSize[0].z, roomSize[1].z);

                } while (!RoomPassThrough.PointInsideWallsRoom(new Vector3(x, y, z), nameWalls));

                GameObject fruitInstanctiate = Instantiate(spawnObject, new Vector3(x, y, z), Quaternion.Euler(new Vector3(0, 0, 0)));
                temporizador = 0;
                //Rigidbody spawnedRigidbody = spawnedBall.GetComponent<Rigidbody>();
                //spawnedRigidbody.velocity = Vector3.zero;
            }
        }
        temporizador = temporizador + Time.deltaTime;
    }

    /*Vector3 GetRoomMeshPosition() {
        Vector3 roomMeshPosition = new Vector3(0,0,0);
        GameObject roomMesh = GameObject.Find("PTRLGlobalMesh(Clone)");
        if (roomMesh != null) {
            roomMeshPosition = roomMesh.transform.position;
        }
        return roomMeshPosition;
    }
    
    //Get the size of the mixed reality room
    Vector3 GetSizeMXRoom() {
        float x = 0;
        float y = 0;
        float z = 0;

        OVRSceneRoom room = FindAnyObjectByType<OVRSceneRoom>();
        OVRScenePlane floor;
        OVRScenePlane[] walls;

        if (room != null) {
            if (room.Floor != null) {
                floor = room.Floor;
                x = floor.Width; z = floor.Height;
            }

            if (room.Walls != null) {
                    walls = room.Walls;
            }
        }
    
        return new Vector3(x, y, z);
    }*/
}

