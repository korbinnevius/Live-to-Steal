using UnityEngine;

//Credit to Sebastian Lague for the GitHub source code 
//https://github.com/SebLague/Field-of-View/blob/master/Episode%2002/Scripts/FieldOfView.cs
//and YouTube video series to set it up and create the scripts
//https://www.youtube.com/watch?v=rQG9aUWarwE (1)
//https://www.youtube.com/watch?v=73Dc5JTCmKI (2)
//https://www.youtube.com/watch?v=xkcCWqifT9M (3)
public struct ViewCastInfo {
    public bool hit;
    public Vector3 point;
    public float dst;
    public float angle;

    public ViewCastInfo(bool _hit, Vector3 _point, float _dst, float _angle) {
        hit = _hit;
        point = _point;
        dst = _dst;
        angle = _angle;
    }
}
