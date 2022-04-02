using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    public Movement movement;
    public GameObject[] pointsOfInterest; //array com os destinos da cena
    int actPoint; //destino atual baseado na sua posiçao no array
    public bool four; //bool para definir se e a cena 4 ou nao

    void Start()
    {
        movement = GetComponent<Movement>(); //pega o script movement do objeto e guarda na variavel movement
        actPoint = 0; //define o destino atual para zero
    }

    void Update()
    {
        if (transform.position == pointsOfInterest[actPoint].transform.position)//se o objeto chegou ao destino faça
        {
            if (four) //se for a cena 4
            {
                pointsOfInterest[actPoint].GetComponent<Renderer>().material.color = Color.blue; //muda a cor do gameobject de waypoint
            }
            actPoint++; //passa para o proximo objeto do array
            if(actPoint >= 5) //sao 5 waypoints na cena, caso ele já tenha passado pelo waypoint 4 (o ultimo no array)
            {
                actPoint = 0; //volta para o primeiro objeto do array
            }
            movement.ponto = pointsOfInterest[actPoint]; //muda o destino do script Movement
            movement.Reset(); //chama a funçao reset do script movement para se adaptar ao proximo destino
        }
    }
}
