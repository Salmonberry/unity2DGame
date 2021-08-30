using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberController : MonoBehaviour
{
    [Header("Patrol")] public float patrolRadius;
    public float moveSpeed;
    public Transform stoppingA;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
/*移动范围*/
        Vector3 currentPosition = transform.position;
        /*A点*/
        Vector3 pointA = currentPosition + Vector3.left * 5;
        Debug.Log("currentPosition:"+currentPosition);
        Debug.Log("pointA:"+pointA);
        Vector3 pointB = currentPosition + Vector3.right * 5;


        transform.position = Vector2.MoveTowards(transform.position, pointA, moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color32(255, 120, 20, 170);

        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}