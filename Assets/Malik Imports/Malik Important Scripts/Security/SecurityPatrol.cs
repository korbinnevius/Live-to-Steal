using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityPatrol : MonoBehaviour
{
    public enum PatrolState
    {
        None,
        ChasePlayer,
        Patrol
    }
    private GameObject player;

    private NavMeshAgent agent;

    [Header("Visual Settings")]
    
    [Header("Navigation and Patrol Settings")]
    [SerializeField] private LayerMask groundLayer, playerLayer;
    
    // Security Patrol
    private Vector3 destPoint; // The destination that the security guard is walking to
    private bool walkpointSet; // If the security guard is walking to a set point or not
    [SerializeField] private float patrolRange; // How for the security guard is allowed to walk 
    
    //state change
    [SerializeField] private float sightRange;
    [SerializeField] private float _stoppingDistance;
    
    [Header("State")]
    public PatrolState patrolState;

    // Start is called before the first frame update
    void Start()
    { 
        patrolState = PatrolState.Patrol; 
        agent = GetComponent<NavMeshAgent>(); 
        player = GameObject.Find("Player"); // Looks for the gameobject in the hierarchy named Player not a tag
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(transform.position, sightRange, playerLayer))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, sightRange))
            {
                if (hit.collider.gameObject == player)
                {
                    //I see you!
                    patrolState = PatrolState.ChasePlayer;
                }
                else
                {
                    //i see a wall? keep patrolling
                    patrolState = PatrolState.Patrol;
                }
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

        if (patrolState == PatrolState.ChasePlayer)
        {
            // If player 1 is in sight, game over!!!
            BustedTick();
        }
        else if(patrolState == PatrolState.Patrol)
        {
            // If player 1 is not in sight, continue to patrol.
            PatrolTick();
        }
        else
        {
            Debug.Log("No patrol state?");
        }
    }

    // When the security guard locates and walks toward the player
    void BustedTick()
    {
        agent.SetDestination(player.transform.position);
    }

    void PatrolTick()
    {
        //when we are close enough to the target destination, find a new random target destination.
        if (agent.remainingDistance < _stoppingDistance)
        {
            agent.SetDestination(GetValidRandomDestination());
        }
    }

    Vector3 GetValidRandomDestination()
    {
        float z = Random.Range(-patrolRange, patrolRange);
        float x = Random.Range(-patrolRange, patrolRange);

        var position = transform.position;
        Vector3 randomPos = new Vector3(position.x+ x, position.y,  position.z + z);
        
        // The above sets the security guard to walk in any random direction regardless of if the path is walkable
        // or not.

        
        // The below checks for whether or not the proposed walk path is within our NavMesh.
        if (Physics.Raycast(randomPos, Vector3.down, groundLayer))
        {
            walkpointSet = true;
            return randomPos;
        }
        else
        {
            walkpointSet = false;
        }

        return Vector3.zero;
    }
}
