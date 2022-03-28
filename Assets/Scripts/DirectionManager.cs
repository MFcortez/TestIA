using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    public Movement movement;
    public GameObject[] pointsOfInterest;
    int actPoint;
    public bool four;

    void Start()
    {
        movement = GetComponent<Movement>();
        actPoint = 0;
    }

    void Update()
    {
        if (transform.position == pointsOfInterest[actPoint].transform.position)
        {
            if (four)
            {
                pointsOfInterest[actPoint].GetComponent<Renderer>().material.color = Color.blue;
            }
            actPoint++;
            if(actPoint >= 5)
            {
                actPoint = 0;
            }
            movement.ponto = pointsOfInterest[actPoint];
            movement.Reset();
        }
    }
}
