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

    public enum WaypointBehaviour
    {
        PingPong,
        Loop
    }

    private GameObject player;

    private NavMeshAgent agent;

    [Header("Visual Settings")] [Header("Navigation and Patrol Settings")] [SerializeField]
    private LayerMask lineofsightLayer;

    // Security Patrol
    private Vector3 destPoint; // The destination that the security guard is walking to
    // private bool walkpointSet; // If the security guard is walking to a set point or not
  // [SerializeField] private float patrolRange; // How far the security guard is allowed to walk 

    //state change
    [SerializeField] private float maxSightRange;

    [Header("State")] public PatrolState patrolState;
    private PatrolState previousState;
    
    public List<GameObject> _waypoints;
    [SerializeField] float speed = 2;
    int _waypointIndex = 0;
    private int _waypointDirection = 1;
    [SerializeField] private WaypointBehaviour _waypointBehaviour;
    private float _giveUpChaseTimer;
    
    [Tooltip("Time in seconds where we cannot see the player while chasing to stop chasing.")]
    [SerializeField] private float GiveUpChaseTime; 
    
    //Trying Unity Events

    public UnityEvent BeganChase;
    public UnityEvent GoBackToPatrol;
    public GameObject firstSphere;

    // [SerializeField] private bool chase;
    private RaycastHit hit;
    // Start is called before the first frame update
    
    //Audio
    public AudioClip _securityGuardLineFreeze;
    private AudioSource _audioSource;
    [SerializeField] private bool canPlaySecurityGuardLine;
    
    
   
    void Start()
    {
        patrolState = PatrolState.Patrol;
        agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player"); // Looks for the gameobject in the hierarchy named Player not a tag
       // chase = true;
       
       canPlaySecurityGuardLine = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool canSeePlayer = false;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, maxSightRange, lineofsightLayer))
        {
            Debug.DrawLine(transform.position,hit.point,Color.yellow,0.1f);
            if (hit.collider.gameObject == player) //&& chase )
            {
                canSeePlayer = true;
                //I see you!
                patrolState = PatrolState.ChasePlayer;
                //chase = false;
                _giveUpChaseTimer = 0;
            }
        }
 
        
        //if cant see the player... (and are in the chase player state)
        if (!canSeePlayer && patrolState == PatrolState.ChasePlayer)
        {
            _giveUpChaseTimer += Time.deltaTime;

            //Stop chasing the player.
            if (_giveUpChaseTimer > GiveUpChaseTime)
            {
                patrolState = PatrolState.Patrol;
                _giveUpChaseTimer = 0;
            }
        }  

          

            // if (patrolState == PatrolState.Patrol && patrolState == PatrolState.ChasePlayer)
        // {
        //     // If player 1 is not in sight, continue to patrol.
        //     PatrolTick();
        // }
        if (patrolState == PatrolState.ChasePlayer) //&& canPlaySecurityGuardLine)
        {
            if(previousState != PatrolState.ChasePlayer)
            {
                Debug.Log("start chase player");
                //first frame chasing player.
                BeganChase?.Invoke();
                
                _audioSource.clip = _securityGuardLineFreeze;
                canPlaySecurityGuardLine = false;
                _audioSource.Play();
               
            }
            //
            ChasePlayerTick();
        }else if (patrolState == PatrolState.Patrol)
        {
            if (previousState != PatrolState.Patrol)
            {
                Debug.Log("Start Patrol");
                //get closest spot on waypoint path....
                GoBackToPatrol?.Invoke();
            }

            // If player 1 is not in sight, continue to patrol.
            PatrolTick();
        }
        else
        {
            PatrolTick();
            Debug.Log("No state?");
        }

        previousState = patrolState;
    }

    // When the security guard locates and walks toward the player
    public void ChasePlayerTick()
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
        
        Vector3 destination = _waypoints[_waypointIndex].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 1)
        {
            GoToNextWaypoint();
        }
        
        agent.SetDestination(_waypoints[_waypointIndex].transform.position);

    }

    private void GoToNextWaypoint()
    {
        if (_waypointBehaviour == WaypointBehaviour.PingPong)
        {
            if (_waypointIndex + _waypointDirection >= _waypoints.Count || _waypointIndex + _waypointDirection < 0)
            {
                //Flip the direction
                _waypointDirection = _waypointDirection * -1;
            }

            _waypointIndex = _waypointIndex + _waypointDirection;
        }else if (_waypointBehaviour == WaypointBehaviour.Loop)
        {
            _waypointIndex += 1;

            if (_waypointIndex >= _waypoints.Count)
            {
                _waypointIndex = 0;
            }
        }
    }


}


