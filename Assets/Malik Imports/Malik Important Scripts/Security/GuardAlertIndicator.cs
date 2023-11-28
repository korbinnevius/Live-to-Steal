using System;
using UnityEngine;

namespace Navigation
{
    public class GuardAlertIndicator : MonoBehaviour
    {
        
        //New stuff. Just replacing the old guard script with the new so that the alert pops up.
        private MalikTestSecurityPatrol _patrol;
        
        
        
        //private SecurityPatrol _patrol;
        private bool _active = true;
        private void Awake()
        {
            //getcomponentinparent searches self and all parents until finds one.
            _patrol = GetComponentInParent<MalikTestSecurityPatrol>();
            if (_patrol == null)
            {
                // This message informs me if the alert doesn't have the right script attached. It is very helpful.
                //You should do this more often!
                Debug.LogError("Alert must be a child of SecurityPatrol! put this a a child object. Deleting.");
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (_patrol.patrolState == MalikTestSecurityPatrol.PatrolState.ChasePlayer)
            {
                if (!_active)
                {
                    SetChildrenActive(true);
                }
            }
            else
            {
                if (_active)
                {
                    SetChildrenActive(false);  
                }
                
            }
        }

        private void SetChildrenActive(bool isActive)
        {
            _active = isActive;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(isActive);
            }
        }
    }
}