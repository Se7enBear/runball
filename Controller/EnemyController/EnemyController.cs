using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float PatrolRange;
    public float speed;
    private Vector3 guardpoint;
    private Vector3 randomPoint;
    private void Awake()
    {
        guardpoint = transform.position;
        GetNewWayPoint();
    }
    private void Start()
    {
        StartCoroutine(randomwalk()); 
    }
    private void Update()
    {
        if (transform.position==randomPoint)
        {
            GetNewWayPoint();
        }
    }
    private void GetNewWayPoint()
    {
        float randomX = Random.Range(-PatrolRange, PatrolRange);
        float randomZ = Random.Range(-PatrolRange, PatrolRange);
        randomPoint = new Vector3(guardpoint.x + randomX, transform.position.y, guardpoint.z + randomZ);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,PatrolRange);
    }
    IEnumerator randomwalk()
    {

        while (Vector3.Distance(randomPoint, transform.position) >0)
        {
            transform.position=Vector3.MoveTowards(this.transform.position, randomPoint, speed);
            transform.LookAt(randomPoint);
            yield return null;
        }
    }
}
