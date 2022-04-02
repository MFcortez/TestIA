using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inGameTempo = tempo passado desde que o jogo foi iniciado

public class Movement : MonoBehaviour
{
    public float velocity; //velocidade do objeto
    public GameObject ponto; //destino
    Transform thisTransform; 
    Vector3 initialPos; //posiçao inicial
    
    //floats para calcular variação do movimento
    float distance, 
        percorrido, 
        startTime;

    void Start()
    {
        startTime = Time.time; //define o momento inGameTempo em que o objeto começa a se mover
        thisTransform = GetComponent<Transform>();
        initialPos = thisTransform.position; //define a posição inicial do objeto
        distance = Vector3.Distance(initialPos, ponto.transform.position); //pega a distancia entre a posiçao inicial do objeto e seu destino
    }

    public void Reset() //chamado ao mudar de direção
    {
        startTime = Time.time; //define o momento inGameTempo em que o objeto reseta
        initialPos = thisTransform.position; //redefine a posição inicial do objeto para a posição atual
        distance = Vector3.Distance(initialPos, ponto.transform.position); //redefine a distancia entre a posiçao inicial e o destino
    }

    void FixedUpdate()
    {
        percorrido = (Time.time - startTime) * velocity; //define a posição atual do objeto em relaçao ao tempo e sua velocidade
        float fracao = percorrido / distance; //define quanto do caminho ja foi percorrido (0 = inicio / 100 = destino)

        if(thisTransform.position != ponto.transform.position) //se o objeto ainda nao chegou ao destino faça
        {
            thisTransform.position = Vector3.Lerp(initialPos, ponto.transform.position, fracao); //define a posiçao atual do objeto ate ele chegar no destino
        }
    }
}
