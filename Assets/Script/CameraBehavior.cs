using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform jogador;
    Vector3 diferenca;
    // Start is called before the first frame update
    void Start()
    {
        diferenca = transform.position - jogador.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = jogador.position + diferenca;
        posicion.x = 0;
        transform.position = posicion;
    }
}
