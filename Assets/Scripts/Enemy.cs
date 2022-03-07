using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //NavMeshAgent agent;
    public List<Transform> waypoints;
    int actualWaypoint = 0;
    public float speed = 3f;
    bool isMoving;



    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        transform.position = waypoints[0].position;
        //agent.SetDestination(waypoints[actualWaypoint].position);
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)//ismoving = true
        {
            Vector3 distToTarget = waypoints[actualWaypoint].position - transform.position;
            transform.position += distToTarget.normalized *speed* Time.deltaTime;
            if (distToTarget.magnitude < 0.1f)
            {
                isMoving = false;

                actualWaypoint = (actualWaypoint + 1) % waypoints.Count;
                //agent.SetDestination(waypoints[actualWaypoint].position);


            }
        }
        else //ismoving = false
        {

            Vector3 RotLeft = new Vector3(0,-90f,0f);
            transform.Rotate(RotLeft);
            //ROTAR hasta la dirección que toca


            //si la dirección es ya la que toca, 
            Vector3 dirEnemy = transform.forward;
            Vector3 dirToTarget = waypoints[actualWaypoint].position - transform.position;
            float angle = Vector3.Angle(dirEnemy, dirToTarget);
            if (angle < 1f)
            {
                isMoving = true;
            }
        }


    }




}
