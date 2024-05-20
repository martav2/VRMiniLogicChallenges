using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.XR.Oculus;
using UnityEngine;

public class RoomPassThrough : MonoBehaviour
{
    //------------------------------------------------------------------------------
    //funtion Name: RoomIsLoad
    //Return if the Room is loaded
    //------------------------------------------------------------------------------
    public static bool RoomIsLoad() {
        bool isLoad = false;
        OVRSceneRoom room = null;

        if (FindAnyObjectByType<OVRSceneRoom>() != null) {
            room = FindAnyObjectByType<OVRSceneRoom>();
            if (room.Ceiling != null && room.Floor != null && room.Walls != null) {
                if (room.Floor.Boundary.ToArray().Length > 0 && room.Ceiling.Boundary.ToArray().Length > 0) {
                    isLoad = true;
                }
            }
        }
        return isLoad;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetRoom
    //Return the OVRSceneRoom
    //------------------------------------------------------------------------------
    public static OVRSceneRoom GetRoom() {
        return FindAnyObjectByType<OVRSceneRoom>();
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetCeilingAnchors
    //Return the Points x,y,z clockwise from the ceiling mesh
    //------------------------------------------------------------------------------
    public static Vector3[] GetCeilingAnchors() {
        OVRSceneRoom room = GetRoom();
        OVRScenePlane ceiling = room.Ceiling;
        Vector3[] ceilingAnchors = null;

        if (ceiling.Boundary.ToArray().Length > 0) {
            int n = ceiling.Boundary.ToArray().Length;
            ceilingAnchors = new Vector3[n];
            for (int i = 0; i < n; i++) {
                ceilingAnchors[i] = ceiling.transform.TransformPoint(ceiling.Boundary[i]);
            }
        }
        return ceilingAnchors;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetFloorAnchors
    //Return the Points x,y,z clockwise from the Floor mesh
    //------------------------------------------------------------------------------
    public static Vector3[] GetFloorAnchors() {
        OVRSceneRoom room = GetRoom();
        OVRScenePlane floor = room.Floor;
        Vector3[] floorAnchors = null;
        if (floor.Boundary.ToArray().Length > 0) {
            int n = floor.Boundary.ToArray().Length;
            floorAnchors = new Vector3[n];
            for (int i = 0; i < n; i++) {
                floorAnchors[i] = floor.transform.TransformPoint(floor.Boundary[i]);
            }
        }
        return floorAnchors;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetCeilingMaxPoint
    //Return the Point x,y,z Max
    //------------------------------------------------------------------------------
    public static Vector3 GetCeilingMaxPoint() {

        Vector3[] ceilingAnchors = null;
        Vector3 maxPoint = new Vector3();
        float x, y, z;

        if (GetCeilingAnchors() != null) {
            ceilingAnchors = GetCeilingAnchors();
            x = ceilingAnchors[0].x; y = ceilingAnchors[0].y; z = ceilingAnchors[0].z;

            foreach (Vector3 point in ceilingAnchors) {
                if (x < point.x) x = point.x;
                if (y < point.y) y = point.y;
                if (z < point.z) z = point.z;
            }
            maxPoint = new Vector3(x, y, z);
        }
        return maxPoint;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetCeilingMinPoint
    //Return the Point x,y,z Min
    //------------------------------------------------------------------------------
    public static Vector3 GetCeilingMinPoint() {

        Vector3[] ceilingAnchors = null;
        Vector3 minPoint = new Vector3();
        float x, y, z;

        if (GetCeilingAnchors() != null) {
            ceilingAnchors = GetCeilingAnchors();
            x = ceilingAnchors[0].x; y = ceilingAnchors[0].y; z = ceilingAnchors[0].z;

            foreach (Vector3 point in ceilingAnchors) {
                if (x > point.x) x = point.x;
                if (y > point.y) y = point.y;
                if (z > point.z) z = point.z;
            }
            minPoint = new Vector3(x, y, z);
        }
        return minPoint;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetFloorMaxPoint
    //Return the Point x,y,z Max
    //------------------------------------------------------------------------------
    public static Vector3 GetFloorMaxPoint() {

        Vector3[] floorAnchors = null;
        Vector3 maxPoint = new Vector3();
        float x, y, z;

        if (GetFloorAnchors() != null) {
            floorAnchors = GetFloorAnchors();
            x = floorAnchors[0].x; y = floorAnchors[0].y; z = floorAnchors[0].z;

            foreach (Vector3 point in floorAnchors) {
                if (x < point.x) x = point.x;
                if (y < point.y) y = point.y;
                if (z < point.z) z = point.z;
            }
            maxPoint = new Vector3(x, y, z);
        }
        return maxPoint;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetFloorMinPoint
    //Return the Point x,y,z Min
    //------------------------------------------------------------------------------
    public static Vector3 GetFloorMinPoint() {

        Vector3[] floorAnchors = null;
        Vector3 minPoint = new Vector3();
        float x, y, z;

        if (GetFloorAnchors() != null) {
            floorAnchors = GetFloorAnchors();
            x = floorAnchors[0].x; y = floorAnchors[0].y; z = floorAnchors[0].z;

            foreach (Vector3 point in floorAnchors) {
                if (x > point.x) x = point.x;
                if (y > point.y) y = point.y;
                if (z > point.z) z = point.z;
            }
            minPoint = new Vector3(x, y, z);
        }
        return minPoint;
    }

    //------------------------------------------------------------------------------
    //funtion Name: GetMinMaxPoints
    //Return Firts the Points x,y,z Min and Second The max
    //------------------------------------------------------------------------------
    public static Vector3[] GetMinMaxPoints() {

        Vector3[] minMaxPoints = new Vector3[2];
        float x, y, z;

        if (GetCeilingMinPoint().x < GetFloorMinPoint().x) x = GetCeilingMinPoint().x;
        else x = GetFloorMinPoint().x;

        if (GetCeilingMinPoint().y < GetFloorMinPoint().y) y = GetCeilingMinPoint().y;
        else y = GetFloorMinPoint().y;

        if (GetCeilingMinPoint().z < GetFloorMinPoint().z) z = GetCeilingMinPoint().z;
        else z = GetFloorMinPoint().z;

        minMaxPoints[0] = new Vector3(x, y, z);

        if (GetCeilingMaxPoint().x > GetFloorMaxPoint().x) x = GetCeilingMaxPoint().x;
        else x = GetFloorMaxPoint().x;

        if (GetCeilingMaxPoint().y > GetFloorMaxPoint().y) y = GetCeilingMaxPoint().y;
        else y = GetFloorMaxPoint().y;

        if (GetCeilingMaxPoint().z > GetFloorMaxPoint().z) z = GetCeilingMaxPoint().z;
        else z = GetFloorMaxPoint().z;

        minMaxPoints[1] = new Vector3(x, y, z);

        return minMaxPoints;
    }

    //------------------------------------------------------------------------------
    //funtion Name: PointInsideWallsRoom
    //Return if the point is inside the walls room
    //------------------------------------------------------------------------------
    public static bool PointInsideWallsRoom(Vector3 point, string nameWalls) {
        bool isInside = false;
        int impar = 0;

        RaycastHit[] hitInfo;
        hitInfo = Physics.RaycastAll(point, new Vector3(1, 0, 0), 100.0f);
        foreach (RaycastHit hit in hitInfo) {
            if (hit.collider.gameObject.name == nameWalls) {
                impar++;
            }
        }

        if (impar % 2 != 0) isInside = true;

        return isInside;
    }
}
