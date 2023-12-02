using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    private Camera[] Cameras;
    public bool searchAllChildrenForCameras;
    private int activeCameraIndex = 0;
    void Awake()
    {
        if (searchAllChildrenForCameras)
        {
            Cameras = GetComponentsInChildren<Camera>(true);
        }
        SetActiveCamera(activeCameraIndex);
    }

    void SetActiveCamera(int index)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            bool active = i == index;
            Cameras[i].gameObject.SetActive(active);
        }
    }
    [ContextMenu("Next Camera")]
    public void NextCamera()
    {
        activeCameraIndex++;
        if (activeCameraIndex >= Cameras.Length)
        {
            activeCameraIndex = 0;
        }
        SetActiveCamera(activeCameraIndex);
    }
    [ContextMenu("Previous Camera")]
    public void PreviousCamera()
    {
        activeCameraIndex--;
        if (activeCameraIndex < 0)
        {
            activeCameraIndex = Cameras.Length - 1;
        }
        SetActiveCamera(activeCameraIndex);
    }
}
