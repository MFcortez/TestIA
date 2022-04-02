using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inGameTempo = tempo passado desde que o jogo foi iniciado

public class Movement : MonoBehaviour
{
    public float velocity; //velocidade do objeto
    public GameObject ponto; //destino
    Transform thisTransform; 
    Vector3 initialPos; //posi�ao inicial
    
    //floats para calcular varia��o do movimento
    float distance, 
        percorrido, 
        startTime;

    void Start()
    {
        startTime = Time.time; //define o momento inGameTempo em que o objeto come�a a se mover
        thisTransform = GetComponent<Transform>();
        initialPos = thisTransform.position; //define a posi��o inicial do objeto
        distance = Vector3.Distance(initialPos, ponto.transform.position); //pega a distancia entre a posi�ao inicial do objeto e seu destino
    }

    public void Reset() //chamado ao mudar de dire��o
    {
        startTime = Time.time; //define o momento inGameTempo em que o objeto reseta
        initialPos = thisTransform.position; //redefine a posi��o inicial do objeto para a posi��o atual
        distance = Vector3.Distance(initialPos, ponto.transform.position); //redefine a distancia entre a posi�ao inicial e o destino
    }

    void FixedUpdate()
    {
        percorrido = (Time.time - startTime) * velocity; //define a posi��o atual do objeto em rela�ao ao tempo e sua velocidade
        float fracao = percorrido / distance; //define quanto do caminho ja foi percorrido (0 = inicio / 100 = destino)

        if(thisTransform.position != ponto.transform.position) //se o objeto ainda nao chegou ao destino fa�a
        {
            thisTransform.position = Vector3.Lerp(initialPos, ponto.transform.position, fracao); //define a posi�ao atual do objeto ate ele chegar no destino
        }
    }
}
