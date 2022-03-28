using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity;
    public GameObject ponto;
    Transform thisTransform;
    Vector3 initialPos;
    float distance, percorrido, startTime;

    void Start()
    {
        startTime = Time.time;
        thisTransform = GetComponent<Transform>();
        initialPos = thisTransform.position;
        distance = Vector3.Distance(thisTransform.position, ponto.transform.position);
    }


    void Update()
    {

        percorrido = (Time.time - startTime) + velocity;
        float fracao = percorrido / distance;

        if(thisTransform.position != ponto.transform.position)
        {
            thisTransform.position = Vector3.Lerp(initialPos, ponto.transform.position, fracao);
        }
    }
}
