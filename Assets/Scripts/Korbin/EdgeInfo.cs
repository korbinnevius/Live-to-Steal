using UnityEngine;


//originally in field of view script
//Hunter moved this into its own script

public struct EdgeInfo {
    public Vector3 pointA;
    public Vector3 pointB;

    public EdgeInfo(Vector3 _pointA, Vector3 _pointB) {
        pointA = _pointA;
        pointB = _pointB;
    }
}
