using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float patrolRange = 10f;
    public Transform[] patrolPoints;
    public float detectionRadius = 5f;
    public Transform player;
    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;
    private Vector3 targetPoint;

    void Start()
    {                                                       //navmesh
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolPoint();
        agent = GetComponent<NavMeshAgent>();
        SetRandomDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                MoveToNextPatrolPoint();
            }
        }
        if (agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }
    }
    void MoveToNextPatrolPoint()                       //enemy patrolling
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
    void SetRandomDestination()
    {
        // Generate a random point within the patrol range
        Vector3 randomDirection = Random.insideUnitSphere * patrolRange;
        randomDirection += transform.position;

        // Find the nearest point on the NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRange, NavMesh.AllAreas))
        {
            targetPoint = hit.position;
            agent.SetDestination(targetPoint);
        }
    }

    

    
}
