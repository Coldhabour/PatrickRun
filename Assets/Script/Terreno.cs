using UnityEngine;

public class Terreno : MonoBehaviour
{
    SpawnerTerreno terrenospawn;

    // Start is called before the first frame update
    void Start()
    {
        terrenospawn = GameObject.FindObjectOfType<SpawnerTerreno>();
        
    }

    private void OnTriggerExit(Collider other)
    {
        terrenospawn.SpawnarTerreno();
        Destroy(gameObject, 2);

    }
   
  
    
        // Update is called once per frame
        void Update()
        {

        }
}

