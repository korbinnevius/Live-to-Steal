using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class MalikTestSecurityPatrol : MonoBehaviour
{
    public enum PatrolState
    {
        None,
        ChasePlayer,
        Patrol
    }

    private GameObject player;

    private NavMeshAgent agent;

    [Header("Visual Settings")] [Header("Navigation and Patrol Settings")] [SerializeField]
    private LayerMask groundLayer, playerLayer;

    // Security Patrol
    private Vector3 destPoint; // The destination that the security guard is walking to
    private bool walkpointSet; // If the security guard is walking to a set point or not
    [SerializeField] private float patrolRange; // How for the security guard is allowed to walk 

    //state change
    [SerializeField] private float sightRange;
    [SerializeField] private float _stoppingDistance;

    [Header("State")] public PatrolState patrolState;



    //New stuff
    public List<GameObject> _waypoints;
    [SerializeField] float speed = 2;
    int index = 0;
    
    
    //Trying Unity Events

    public UnityEvent BeganChase;

    public UnityEvent GoBackToPatrol;

    public GameObject firstSphere;
    
    

   // [SerializeField] private bool chase;

    // Start is called before the first frame update
    void Start()
    {
        patrolState = PatrolState.Patrol;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player"); // Looks for the gameobject in the hierarchy named Player not a tag
       // chase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, sightRange, playerLayer))
        { 
            
            
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit,
                    sightRange))
            {
                Debug.Log("I am updating the Raycast");
                if (hit.collider.gameObject == player) //&& chase )
                {
                    Debug.Log("I am stuck chasing the player");
                    //I see you!
                    patrolState = PatrolState.ChasePlayer;
                    Debug.Log("I see you!");
                    //chase = false;
                }
                if (hit.collider.gameObject != player) //&& chase == false )
                {
                    Debug.Log("I want to chase the player but I am told to patrol");
                    //i see a wall? keep patrolling
                    patrolState = PatrolState.Patrol;
                    this.gameObject.transform.position = firstSphere.transform.position;
                    // chase = true;
                }
                
                
                // else
                // {
                //     //i see a wall? keep patrolling
                //     patrolState = PatrolState.Patrol;
                // }
            }

        }
        else
        {
            //i'm not close enough to see the player, even if it would be in line of sight
            patrolState = PatrolState.Patrol;
        }
        // Checks for the player in the specified radius. If it finds anything on Player 1's layer, 
        // in the sightRange amount around the player transform it will set playerInsight as true.
        // If nothing is detected, it would return false.

        
        // if (patrolState == PatrolState.Patrol && patrolState == PatrolState.ChasePlayer)
        // {
        //     // If player 1 is not in sight, continue to patrol.
        //     PatrolTick();
        // }
        if (patrolState == PatrolState.ChasePlayer)
        {
            // If player 1 is in sight, game over!!!
            BustedTick();
            
            
            BeganChase?.Invoke();
            
            
            //I tried the coroutine below
            //ChasePlayerThenStop();
        }
        if (patrolState == PatrolState.Patrol)
        {
            // If player 1 is not in sight, continue to patrol.
            PatrolTick();
            
            GoBackToPatrol?.Invoke();

        }
        else
        {
            PatrolTick();
            Debug.Log("No patrol state?");
        }
    }

    // When the security guard locates and walks toward the player
    public void BustedTick()
    {
        agent.SetDestination(player.transform.position);
    }

    //Newly edited Patrol System
    public void  PatrolTick()
    {
        //when we are close enough to the target destination, find a new random target destination.
        
            // Enables the security guards to move toward the gameobjects in the _waypoints list. Once it reaches the last
            // gameobject in the list, the security guard will go back to the position of the first gameobject
            //  in the list and begin the pattern again.
        
            
            Vector3 destination = _waypoints[index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPos;

            float distance = Vector3.Distance(transform.position, destination);
            if (distance <= 1)
            {
                if (index < _waypoints.Count - 1)
                {
                    index++;
                }

                else
                {
                    if (index >= _waypoints.Count - 1)
                    {
                        index = 0;
                    }

                }

            }

    }

    // public void ChasePlayerThenStop()
    // {
    //     StartCoroutine(Wait());
    // }
    //
    // IEnumerator Wait()
    // {
    //     yield return new WaitForSeconds(2f);
    //     BustedTick();
    // }


    
}


