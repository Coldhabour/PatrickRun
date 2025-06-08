using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarMoeda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnarMoedas();
    }
    public GameObject prefabMoeda;
    public GameObject newgameobject;
    
    void SpawnarMoedas()
    {
        int moedasSpawnadas = 10;
        for (int i = 0; i < moedasSpawnadas; i++)
        {
            newgameobject.transform.position = transform.position;
            GameObject temp = Instantiate(prefabMoeda, newgameobject.transform);
            temp.transform.position = PontoAleatorio(GetComponent<Collider>());
        }
    }
    Vector3 PontoAleatorio(Collider collider)
    {
        Vector3 ponto = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (ponto != collider.ClosestPoint(ponto))
        {
            ponto = PontoAleatorio(collider);
        }
        
        ponto.y = 2;
        return ponto;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
