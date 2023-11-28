using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public GameObject detectionZone;
    public float activationDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        detectionZone.SetActive(false);
        StartCoroutine(ActivateDeactivateRoutine());
        
    }

    private IEnumerator ActivateDeactivateRoutine()
    {
        while (true)
        {
            detectionZone.SetActive(true);

            yield return new WaitForSeconds(activationDelay);
            
            detectionZone.SetActive(false);

            yield return new WaitForSeconds(activationDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
