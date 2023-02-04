using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    private float distanceToTarget = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(Transform waypoint)
    {
        StartCoroutine(Movimiento(waypoint));
        //transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.position, waypoints[0].position, speed * Time.deltaTime);
    }

    public IEnumerator Movimiento(Transform waypoint)
    {
        while(Vector3.Distance(transform.position, waypoint.position) > distanceToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, speed * Time.deltaTime);
            //transform.position = Vector3.Slerp(transform.position, waypoints[0].position, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

    }
}
